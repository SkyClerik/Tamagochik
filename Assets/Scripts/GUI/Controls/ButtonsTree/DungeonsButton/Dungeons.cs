namespace Hud.Buttons
{
    using System.Collections.Generic;
    using UnityEngine;
    using Data.Dungeon;
    using Behaviours;
    using System;
    using Data.Resources;
    using Data.Items;

    public class Dungeons : IInit
    {
        private GameDataContainer _gameDataContainer;
        private HudIconData _imageIconData;
        private DungeonsData _dungeonsData;
        private ResourcesData _resourcesData;
        private ItemsData _itemsData;

        private ButtonElement[] _buttons;
        private GUISkin _guiSkin;
        private GUIStyle _buttonActive;
        private GUIStyle _buttonLock;
        private GUIStyle _iconStyle;
        private const string _leftButtonStyle = "leftButton";
        private const string _lockButtonStyle = "lockButton";
        private const string _onlyIcon = "onlyIcon";

        public void Init(params object[] list)
        {
            _gameDataContainer = GameDataContainer.Instance;
            _imageIconData = _gameDataContainer.GetHudIconData;
            _dungeonsData = _gameDataContainer.GetDungeonsData;
            _resourcesData = _gameDataContainer.GetResourcesData;
            _itemsData = _gameDataContainer.GetItemsData;

            _guiSkin = _gameDataContainer.StandartGuiSkin;
            _buttonActive = _guiSkin.GetStyle($"{_leftButtonStyle}");
            _buttonLock = _guiSkin.GetStyle($"{_lockButtonStyle}");
            _iconStyle = _guiSkin.GetStyle($"{_onlyIcon}");

            Texture2D IconClose = TextureConverter.SpriteToTexture(_imageIconData.Close);

            _buttons = new ButtonElement[_dungeonsData.Dungeons.Count];
            for (int i = 0; i < _dungeonsData.Dungeons.Count; i++)
            {
                _buttons[i] = CreateButton(_dungeonsData.Dungeons[i], Call, i);
            }

            //WindowManagement.Instance.GetButtonsHud.Init(_buttons, BackButton);
        }

        private ButtonElement CreateButton(Dungeon dungeon, Action<int> callbackInt, int index)
        {
            Texture2D dungeonIcon = TextureConverter.SpriteToTexture(dungeon.Icon);
            var mainIcon = new IconElement(new GUIContent(dungeonIcon), _iconStyle);

            List<InfoElement> additionalInfo = new();
            foreach (var lutInfo in dungeon.LutInfo)
            {
                Texture2D resourceIcon = null;
                if (lutInfo.GetResourceType != ResourceTypes.None)
                {
                    CustomResource resourceBase = _resourcesData.GetResourceBase(lutInfo.GetResourceType);
                    resourceIcon = TextureConverter.SpriteToTexture(resourceBase.Icon);
                }
                if (lutInfo.GetItemId >= 0)
                {
                    ItemBase itemBase = _itemsData.GetItemBase(lutInfo.GetItemId);
                    resourceIcon = TextureConverter.SpriteToTexture(itemBase.Icon);
                }

                string resourceAmount = lutInfo.GetAmount.ToString();
                additionalInfo.Add(new InfoElement(new GUIContent(resourceAmount, resourceIcon), _iconStyle));
            }

            var kd = dungeon.Busy ? dungeon.CurrentKDTime : dungeon.KdTime;

            if (dungeon.Busy is not true)
            {
                return new ButtonElement(
                    mainIcon: mainIcon,
                    mainButton: new ViewElementButton(
                        buttonText: dungeon.Name,
                        callbackInt: callbackInt,
                        callbackParam: index,
                        style: _buttonActive,
                        active: true),
                    additionalInfo: additionalInfo,
                    endIcon: new EndIcon(kd, _iconStyle));
            }
            else
            {
                return new ButtonElement(
                   mainIcon: mainIcon,
                   mainButton: new ViewElementButton(
                       buttonText: dungeon.Name,
                       callback: null,
                       style: _buttonLock,
                       active: false),
                   additionalInfo: additionalInfo,
                   endIcon: new EndIcon(kd, _iconStyle));
            }
        }

        private void Call(int dungeonsListIndex)
        {
            new DungeonInfo().Init(_dungeonsData.Dungeons[dungeonsListIndex]);
        }

        private void BackButton()
        {
            new EmptyPersonalSpace().Init();
        }
    }
}