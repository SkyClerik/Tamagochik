namespace Hud.Buttons
{
    using UnityEngine;
    public class KraftTypesList : IInit
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

        public void Init(params object[] list)
        {
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
                    mainIcon: new IconElement(new GUIContent(IconClose), _iconStyle),
                    mainButton: new ViewElementButton(
                        buttonText: "Предмет", 
                        callback: ()=>{ new KraftObjects().Init(StorageTypes.Item);},
                        style: _buttonActive, 
                        active: true),
                    additionalInfo: null,
                    endIcon: null),

                new ButtonElement(
                    mainIcon: new IconElement(new GUIContent(IconClose), _iconStyle),
                    new ViewElementButton(
                        buttonText: "Оборудование",
                        callback: ()=>{ new KraftObjects().Init(StorageTypes.Module);},
                        style: _buttonActive, 
                        active: true),
                    additionalInfo: null,
                    endIcon: null),

                new ButtonElement(
                    mainIcon: new IconElement(new GUIContent(IconClose), _iconStyle),
                    mainButton: new ViewElementButton(
                        buttonText: "Корпус",
                        callback: ()=>{ new KraftObjects().Init(StorageTypes.Hull);},
                        style: _buttonActive, 
                        active: true),
                    additionalInfo: null,
                    endIcon: null),

                new ButtonElement(
                    mainIcon: new IconElement(new GUIContent(IconClose), _iconStyle),
                    mainButton: new ViewElementButton(
                        buttonText: "Мебель",
                        callback: ()=>{ new KraftObjects().Init(StorageTypes.Furniture);},
                        style: _buttonActive, 
                        active: true),
                    additionalInfo: null,
                    endIcon: null),
            };

            //WindowManagement.Instance.GetButtonsHud.Init(_buttons, BackButton);
        }

        private void BackButton()
        {
            new EmptyPersonalSpace().Init();
        }
    }
}