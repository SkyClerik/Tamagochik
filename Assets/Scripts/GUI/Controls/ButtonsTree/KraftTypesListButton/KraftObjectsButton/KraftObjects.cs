namespace Hud.Buttons
{
    using UnityEngine;
    using Data.Item;
    using System.Collections.Generic;

    public class KraftObjects : IInit
    {
        private GameDataContainer _gameDataContainer;
        private ItemsData _itemsData;
        private List<ButtonElement> _buttons;

        //private GUISkin _guiSkin;
        private GUIStyle _buttonActive;
        private GUIStyle _buttonLock;
        private GUIStyle _iconStyle;
        private const string _leftButtonStyle = "leftButton";
        private const string _lockButtonStyle = "lockButton";
        private const string _onlyIcon = "onlyIcon";
        //TODO del
        public void Init(params object[] list)
        {
            StorageTypes type = (StorageTypes)list[0];

            _gameDataContainer = GameDataContainer.Instance;
            _itemsData = _gameDataContainer.GetItemsData;
            //_guiSkin = _gameDataContainer.StandartGuiSkin;
            //_buttonActive = _guiSkin.GetStyle($"{_leftButtonStyle}");
            //_buttonLock = _guiSkin.GetStyle($"{_lockButtonStyle}");
            //_iconStyle = _guiSkin.GetStyle($"{_onlyIcon}");
            _buttons = new List<ButtonElement>();

            for (int i = 0; i < _itemsData.Items.Count; i++)
            {
                if (_itemsData.Items[i].StorageType == type)
                {
                    _buttons.Add(new ButtonElement(
                        mainIcon: new IconElement(new GUIContent(TextureConverter.SpriteToTexture(_itemsData.Items[i].Icon)), _iconStyle),
                        mainButton: new ViewElementButton(
                        buttonText: _itemsData.Items[i].Name,
                        callback: null,
                        callbackParam: _itemsData.Items[i].Id,
                        style: _buttonActive,
                        active: true),
                        additionalInfo: null,
                        endIcon: null)
                        );
                }
            }

            WindowManagement.Instance.MainHuds(false);
            WindowManagement.Instance.GetKraftHud.Init(_buttons.ToArray());
        }
    }
}