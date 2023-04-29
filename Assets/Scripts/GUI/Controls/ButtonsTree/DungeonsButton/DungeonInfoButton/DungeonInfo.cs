namespace Hud.Buttons
{
    using UnityEngine;
    using Behaviours;
    using Data.Dungeon;

    public class DungeonInfo : IInit
    {
        private GameDataContainer _gameDataContainer;
        private HudIconData _imageIconData;
        private DungeonsData _dungeonsData;
        private ButtonElement[] _buttons;
        private GUISkin _guiSkin;
        private GUIStyle _buttonActive;
        private GUIStyle _buttonLock;
        private GUIStyle _iconStyle;
        private const string _leftButtonStyle = "leftButton";
        private const string _lockButtonStyle = "lockButton";
        private const string _onlyIcon = "onlyIcon";

        private Dungeon _dungeon;

        public void Init(params object[] list)
        {
            _dungeon = list[0] as Dungeon;

            _gameDataContainer = GameDataContainer.Instance;
            _imageIconData = _gameDataContainer.GetHudIconData;
            _dungeonsData = _gameDataContainer.GetDungeonsData;
            _guiSkin = _gameDataContainer.StandartGuiSkin;
            _buttonActive = _guiSkin.GetStyle($"{_leftButtonStyle}");
            _buttonLock = _guiSkin.GetStyle($"{_lockButtonStyle}");
            _iconStyle = _guiSkin.GetStyle($"{_onlyIcon}");

            Texture2D IconClose = TextureConverter.SpriteToTexture(_imageIconData.Close);

            _buttons = new ButtonElement[]
            {
                new ButtonElement(
                    new IconElement(new GUIContent(IconClose), _iconStyle),
                    new ViewElementButton($"{_dungeon.Name}", TestButton, style: _lockButtonStyle, active: false),
                    null,
                    null),

                new ButtonElement(
                    new IconElement(new GUIContent(IconClose), _iconStyle),
                    new ViewElementButton("Уровень сложности средний", TestButton, style: _lockButtonStyle, active: false),
                    null,
                    null),

                new ButtonElement(
                    new IconElement(new GUIContent(IconClose), _iconStyle),
                    new ViewElementButton("Собрать отряд", AssembleSquad, style: _buttonActive, active: true),
                    null,
                    null),

                new ButtonElement(
                    new IconElement(new GUIContent(IconClose), _iconStyle),
                    new ViewElementButton("Информация", TestButton, style: _buttonActive, active: true),
                    null,
                    null),

                new ButtonElement(
                    new IconElement(new GUIContent(IconClose), _iconStyle),
                    new ViewElementButton("Возможные ресурсы", TestButton, style: _lockButtonStyle, active: false),
                    null,
                    null),
            };

            //WindowManagement.Instance.GetButtonsHud.Init(_buttons, BackButton);
        }

        private void AssembleSquad()
        {
            //WindowManagement.Instance.GetButtonsHud.enabled = false;
            //new AssembleSquad().Init(_dungeon);
        }

        private void TestButton()
        {
            Debug.Log("Тестовая кнопочка отработала как часики!");
        }

        private void BackButton()
        {
            new Dungeons().Init();
        }
    }
}