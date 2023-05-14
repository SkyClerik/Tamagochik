namespace Hud.Buttons
{
    using Data.Units;
    using System;
    using UnityEngine;

    public class Units : IInit
    {
        private GameDataContainer _gameDataContainer;
        private SpriteData _spriteData;
        private ButtonElement[] _buttons;
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
            _gameDataContainer = GameDataContainer.Instance;
            _spriteData = _gameDataContainer.GetSpriteData;
            //_guiSkin = _gameDataContainer.StandartGuiSkin;
            //_buttonActive = _guiSkin.GetStyle($"{_leftButtonStyle}");
            //_buttonLock = _guiSkin.GetStyle($"{_lockButtonStyle}");
            //_iconStyle = _guiSkin.GetStyle($"{_onlyIcon}");

            Texture2D IconClose = TextureConverter.SpriteToTexture(_spriteData.Close);

            //_buttons = new ButtonElement[_unitsData.Units.Count];
            //for (int i = 0; i < _unitsData.Units.Count; i++)
            //{
            //    _buttons[i] = CreateButton(_unitsData.Units[i], UnitInfo, i);
            //}

            //WindowManagement.Instance.GetButtonsHud.Init(_buttons, BackButton);
        }

        private ButtonElement CreateButton(UnitBase unit, Action<int> callback, int index)
        {
            Texture2D dungeonIcon = TextureConverter.SpriteToTexture(unit.Icon);
            var mainIcon = new IconElement(new GUIContent(dungeonIcon), _iconStyle);

            if (unit.Busy is not true)
            {
                return new ButtonElement(
                    mainIcon: mainIcon,
                    mainButton: new ViewElementButton(
                        buttonText: unit.Name,
                        callbackInt: callback,
                        callbackParam: index,
                        style: _buttonActive,
                        active: true),
                    additionalInfo: null,
                    endIcon: null);
            }
            else
            {
                return new ButtonElement(
                   mainIcon: mainIcon,
                   mainButton: new ViewElementButton(
                       buttonText: unit.Name,
                       callback: null,
                       style: _buttonLock,
                       active: false),
                   additionalInfo: null,
                   endIcon: null);
            }
        }

        private void UnitInfo(int index)
        {
            //new UnitInfo().Init(_unitsData.Units[index]);
            //Debug.Log("“естова€ кнопочка отработала как часики!");
        }

        private void BackButton()
        {
            new EmptyPersonalSpace().Init();
        }
    }
}