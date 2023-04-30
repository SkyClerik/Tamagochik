namespace Hud.Buttons
{
    using UnityEngine;
    using Data.Units;

    public class UnitInfo : IInit
    {
        private GameDataContainer _gameDataContainer;
        private SpriteData _spriteData;
        private ButtonElement[] _buttons;
        private GUISkin _guiSkin;
        private GUIStyle _buttonActive;
        private GUIStyle _buttonLock;
        private GUIStyle _iconStyle;
        private const string _leftButtonStyle = "leftButton";
        private const string _lockButtonStyle = "lockButton";
        private const string _onlyIcon = "onlyIcon";

        private UnitBase _unitBase;

        public void Init(params object[] list)
        {
            _unitBase = list[0] as UnitBase;

            _gameDataContainer = GameDataContainer.Instance;
            _spriteData = _gameDataContainer.GetSpriteData;
            _guiSkin = _gameDataContainer.StandartGuiSkin;
            _buttonActive = _guiSkin.GetStyle($"{_leftButtonStyle}");
            _buttonLock = _guiSkin.GetStyle($"{_lockButtonStyle}");
            _iconStyle = _guiSkin.GetStyle($"{_onlyIcon}");

            Texture2D IconClose = TextureConverter.SpriteToTexture(_spriteData.Close);

            _buttons = new ButtonElement[]
            {
               new ButtonElement(
                    new IconElement(new GUIContent(IconClose), _iconStyle),
                    new ViewElementButton(_unitBase.Name, TestButton, style: _buttonLock, active: false),
                    null,
                    null),

                new ButtonElement(
                    mainIcon: new IconElement(new GUIContent(IconClose), _iconStyle),
                    mainButton: new ViewElementButton(
                        buttonText: "Экипировка",
                        callback: Equipment,
                        style: _buttonActive,
                        active: true),
                    additionalInfo: null,
                    endIcon: null),

                new ButtonElement(
                    new IconElement(new GUIContent(IconClose), _iconStyle),
                    new ViewElementButton("Характеристики", TestButton, style: _buttonLock, active: false),
                    null,
                    null),

                new ButtonElement(
                    new IconElement(new GUIContent(IconClose), _iconStyle),
                    new ViewElementButton("Отказаться", TestButton, style: _buttonLock, active: false),
                    null,
                    null),
            };

            //WindowManagement.Instance.GetButtonsHud.Init(_buttons, BackButton);
        }

        private void Equipment()
        {
            //WindowManagement windowManagement = WindowManagement.Instance;
            //windowManagement.GetEquipmentHud.enabled = true;
            //windowManagement.GetEquipmentHud.Init(_unitBase);
        }

        private void TestButton()
        {
            Debug.Log("Тестовая кнопочка отработала как часики!");
        }

        private void BackButton()
        {
            new Units().Init();
        }
    }
}