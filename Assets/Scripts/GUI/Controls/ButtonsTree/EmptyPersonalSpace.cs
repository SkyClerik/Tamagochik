namespace Hud.Buttons
{
    using UnityEngine;

    public class EmptyPersonalSpace : IInit
    {
        private GameDataContainer _gameDataContainer;
        private HudIconData _imageIconData;
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
            _guiSkin = _gameDataContainer.StandartGuiSkin;
            _buttonActive = _guiSkin.GetStyle($"{_leftButtonStyle}");
            _buttonLock = _guiSkin.GetStyle($"{_lockButtonStyle}");
            _iconStyle = _guiSkin.GetStyle($"{_onlyIcon}");

            Texture2D IconClose = TextureConverter.SpriteToTexture(_imageIconData.Close);

            _buttons = new ButtonElement[]
            {
                new ButtonElement(
                    new IconElement(new GUIContent(IconClose), _iconStyle),
                    new ViewElementButton(buttonText: "Создать", callback: KraftTypesListButton, style: _buttonActive, active: true),
                    null,
                    null),

                new ButtonElement(
                    new IconElement(new GUIContent(IconClose), _iconStyle),
                    new ViewElementButton(buttonText: "Наемники", callback: UnitsButton, style: _buttonActive, active: true),
                    null,
                    null),

                new ButtonElement(
                    new IconElement(new GUIContent(IconClose), _iconStyle),
                    new ViewElementButton(buttonText: "Помещения", callback: RoomsButton, style: _buttonActive, active: true),
                    null,
                    null),

                new ButtonElement(
                    new IconElement(new GUIContent(IconClose), _iconStyle),
                    new ViewElementButton(buttonText: "Подземелья", callback: DungeonsButton, style: _buttonActive, active: true),
                    null,
                    null),

                new ButtonElement(
                    new IconElement(new GUIContent(IconClose), _iconStyle),
                    new ViewElementButton(buttonText: "Задания (Порт)", callback: null, style: _buttonActive, active: true),
                    null,
                    null),

                //new ButtonElement(
                //    new IconElement(new GUIContent(IconClose), _iconStyle),
                //    new ViewElementButton(buttonText: "4 КноПочка", callback : TestButton, style: _buttonActive, active: true),
                //    new System.Collections.Generic.List<InfoElement>()
                //        {
                //        new InfoElement(new GUIContent(IconClose), _iconStyle),
                //        new InfoElement(new GUIContent(IconClose), _iconStyle),
                //        },
                //    new System.Collections.Generic.List<InfoElement>()
                //        {
                //        new InfoElement(new GUIContent(IconClose), _iconStyle),
                //        new InfoElement(new GUIContent(IconClose), _iconStyle),
                //        },
                //    new EndIcon(33, _iconStyle)),

                new ButtonElement(
                    new IconElement(new GUIContent(IconClose), _iconStyle),
                    new ViewElementButton(buttonText: "Закончить день", callback : EndTheDay, style: _buttonActive, active: true),
                    null,
                    null),
            };

            //WindowManagement.Instance.GetButtonsHud.Init(_buttons, null);
        }

        private void KraftTypesListButton()
        {
            new KraftTypesList().Init();
        }

        private void UnitsButton()
        {
            new Units().Init();
        }

        private void RoomsButton()
        {
            //new Rooms().Init();
        }

        private void DungeonsButton()
        {
            new Dungeons().Init();
        }

        private void TestButton()
        {
            Debug.Log("Тестовая кнопочка отработала как часики!");
        }

        private void EndTheDay()
        {
            GameDataContainer.Instance.GetGameData.Day++;
        }
    }
}