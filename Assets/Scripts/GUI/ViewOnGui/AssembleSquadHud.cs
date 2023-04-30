using Data.Dungeon;
using Data.Rects;
using Data.Units;
using Hud.Buttons;
using System;
using UnityEngine;

public class AssembleSquadHud : MonoBehaviour
{
    private GameDataContainer _gameDataContainer;
    private SpriteData _spriteData;

    private Rect _buttonsArea;
    private Rect _leftArea;
    private Rect _partyButtonsArea;
    private Rect _startButtonArea;

    private ButtonElement[] _unitsButtons;
    private ButtonElement[] _partyButtons;
    private ButtonElement _startButton;
    private Dungeon _dungeon;
    private GUILayoutOption[] _buttonOptions;
    private int _icoSize;
    private int _maxSpaceFromEndIcon = 7; // Магическое число. Посчитано как (ButtonSizeWidth/ButtonSizeHeight - 1)==(256/32-1)
    private int _partyCount = 4; // Магическое число. Временно ограничиваю партию.
    private Action _backToAction;

    private GUISkin _guiSkin;
    private GUIStyle _buttonActive;
    private GUIStyle _buttonLock;
    private GUIStyle _iconStyle;
    private const string _leftButtonStyle = "leftButton";
    private const string _lockButtonStyle = "lockButton";
    private const string _onlyIcon = "onlyIcon";
    private const string _startText = "Go to Dungeon";

    private void Start()
    {
        var gameDataContainer = GameDataContainer.Instance;
        RectsData rectsData = gameDataContainer.GetRectsData;
        _buttonOptions = rectsData.MainButtonsOption;
        _icoSize = rectsData.GetIcoSize;
        _leftArea = rectsData.LeftArea;
        _buttonsArea = rectsData.ButtonsArea;
        _partyButtonsArea = new Rect(_buttonsArea.xMax, _buttonsArea.y, _buttonsArea.width, _icoSize * _partyCount);
        _startButtonArea = new Rect(_partyButtonsArea.x, _partyButtonsArea.yMax, _partyButtonsArea.width, _icoSize);
        _gameDataContainer = GameDataContainer.Instance;
        _spriteData = _gameDataContainer.GetSpriteData;
        _guiSkin = _gameDataContainer.StandartGuiSkin;
        _buttonActive = _guiSkin.GetStyle($"{_leftButtonStyle}");
        _buttonLock = _guiSkin.GetStyle($"{_lockButtonStyle}");
        _iconStyle = _guiSkin.GetStyle($"{_onlyIcon}");
        enabled = false;
    }

    public void Init(Action backToAction, Dungeon dungeon)
    {
        _dungeon = dungeon;
        _backToAction = backToAction;

        CreateUnitButtons();
        CreatePartyButtons();
        CreateStartButton();

        enabled = true;
    }

    private void CreateUnitButtons()
    {
        //_unitsButtons = new ButtonElement[_unitsData.Units.Count];
        //for (int i = 0; i < _unitsData.Units.Count; i++)
        //{
        //    _unitsButtons[i] = CreateUnitButton(_unitsData.Units[i], UnitsButton, i);
        //}
    }

    private void CreatePartyButtons()
    {
        _partyButtons = new ButtonElement[_partyCount];
        for (int i = 0; i < _partyButtons.Length; i++)
        {
            _partyButtons[i] = CreateClearPartyButton();
        }
    }

    private void CreateStartButton()
    {
        _startButton = new ButtonElement(
            mainIcon: null,
            mainButton: new ViewElementButton(
                buttonText: _startText,
                callback: null,
                style: _buttonActive,
                active: true),
            additionalInfo: null,
            endIcon: null);
    }

    private ButtonElement CreateUnitButton(UnitBase unitBase, Action<int> callbackInt, int index)
    {
        Texture2D unitIcon = TextureConverter.SpriteToTexture(unitBase.Icon);
        var mainIcon = new IconElement(new GUIContent(unitIcon), _iconStyle);
        var active = unitBase.Busy ? false : true;
        var style = active ? _buttonActive : _buttonLock;
        var callback = active ? callbackInt : null;

        return new ButtonElement(
            mainIcon: mainIcon,
            mainButton: new ViewElementButton(
                buttonText: unitBase.Name,
                callbackInt: callback,
                callbackParam: index,
                style: style,
                active: active),
            additionalInfo: null,
            endIcon: null);
    }

    private ButtonElement CreateClearPartyButton()
    {
        return new ButtonElement(
            mainIcon: new IconElement(new GUIContent(string.Empty), _iconStyle),
            mainButton: new ViewElementButton(
                buttonText: "Свободно",
                callback: null,
                style: _buttonLock,
                active: false),
            additionalInfo: null,
            endIcon: null);
    }

    private void UnitsButton(int u)
    {
        //for (int i = 0; i < _partyButtons.Length; i++)
        //{
        //    if (_partyButtons[i].MainButton.Active == false)
        //    {
        //        _partyButtons[i] = CreateUnitButton(_unitsData.Units[u], PartyButton, i);

        //        _unitsButtons[u].MainButton.CallbackInt = null;
        //        _unitsButtons[u].MainButton.Style = _buttonLock;
        //        _unitsButtons[u].MainButton.Active = false;
        //        break;
        //    }
        //}
    }

    private void PartyButton(int p)
    {
        //for (int i = 0; i < _unitsButtons.Length; i++)
        //{
        //    if (_unitsButtons[i].MainButton.ButtonText == _partyButtons[p].MainButton.ButtonText)
        //    {
        //        _unitsButtons[i] = CreateUnitButton(_unitsData.Units[i], UnitsButton, i);
        //        _partyButtons[p] = CreateClearPartyButton();
        //        return;
        //    }
        //}
    }


    private void OnGUI()
    {
        GUI.skin = _guiSkin;

        ViewBackButton();
        ViewButtonList(_buttonsArea, _unitsButtons);
        ViewButtonList(_partyButtonsArea, _partyButtons);
        ViewStartButton();
    }

    private void ViewBackButton()
    {
        GUILayout.BeginArea(_leftArea);
        if (_backToAction != null)
        {
            if (GUILayout.Button("<"))
            {
                _backToAction.Invoke();
            }
        }
        GUILayout.EndArea();
    }

    private void ViewButtonList(Rect buttonsArea, ButtonElement[] buttonElements)
    {
        GUILayout.BeginArea(buttonsArea);
        for (int i = 0; i < buttonElements?.Length; i++)
        {
            GUILayout.BeginHorizontal();
            ViewIcon(buttonElements[i].MainIcon);
            if (GUILayout.Button(buttonElements[i].MainButton.ButtonText, buttonElements[i].MainButton.Style, _buttonOptions))
            {
                if (buttonElements[i].MainButton.Active)
                {
                    buttonElements[i].MainButton.Callback?.Invoke();
                    buttonElements[i].MainButton.CallbackInt?.Invoke(i);
                }
            }
            GUILayout.EndHorizontal();

            if (buttonElements[i].AdditionalInfo != null)
            {
                GUILayout.BeginHorizontal();
                GUILayout.Space(_icoSize);
                int index = 0;
                foreach (var item in buttonElements[i].AdditionalInfo)
                {
                    ViewIcon(item);
                    index++;
                }

                index = Mathf.Abs(_maxSpaceFromEndIcon - index);
                GUILayout.Space(_icoSize * index);

                if (buttonElements[i].EndIcon != null)
                {
                    ViewIcon(buttonElements[i].EndIcon);
                }

                GUILayout.EndHorizontal();
            }

        }
        GUILayout.EndArea();
    }

    private void ViewStartButton()
    {
        GUILayout.BeginArea(_startButtonArea);
        if (GUILayout.Button(_startButton.MainButton.ButtonText, _startButton.MainButton.Style, _buttonOptions))
        {
            bool partyReady = IsPartyReady();
            if (partyReady is false)
                return;

            _dungeon.StartQuest();

            if (_dungeon.Party == null)
                _dungeon.Party = new System.Collections.Generic.List<UnitBase>();

            //for (int i = 0; i < _unitsButtons.Length; i++)
            //{
            //    for (int p = 0; p < _partyButtons.Length; p++)
            //    {
            //        if (_unitsButtons[i].MainButton.ButtonText == _partyButtons[p].MainButton.ButtonText)
            //        {
            //            _dungeon.Party.Add(_unitsData.Units[i]);
            //            _unitsData.Units[i].Busy = true;
            //        }
            //    }
            //}

            enabled = false;
            new Dungeons().Init();
        }
        GUILayout.EndArea();
    }

    private bool IsPartyReady()
    {
        for (int p = 0; p < _partyButtons.Length; p++)
        {
            if (_partyButtons[p].MainButton.Active)
                return true;
        }
        return false;
    }


    private void ViewIcon(IconElement iconElement)
    {
        GUILayout.Box(iconElement.Content.image, iconElement.GUIStyle, GUILayout.Width(_icoSize), GUILayout.Height(_icoSize));
    }

    private void ViewIcon(InfoElement lutElement)
    {
        GUIStyle uIStyle = new GUIStyle(lutElement.GUIStyle);
        if (lutElement.Content.image != null)
        {
            uIStyle.normal.background = (Texture2D)lutElement.Content.image;
        }

        GUILayout.Box(lutElement.Content.text, uIStyle, GUILayout.Width(_icoSize), GUILayout.Height(_icoSize));
    }

    private void ViewIcon(EndIcon endIcon)
    {
        GUIStyle uIStyle = new GUIStyle(endIcon.GUIStyle);
        if (endIcon.Content.image != null)
        {
            uIStyle.normal.background = (Texture2D)endIcon.Content.image;
        }

        GUILayout.Box(endIcon.Content, uIStyle, GUILayout.Width(_icoSize), GUILayout.Height(_icoSize));
    }
}
