using Hud.Buttons;
using UnityEngine;

[RequireComponent(typeof(KraftHudWindow))]
public class KraftHud : MonoBehaviour
{
    private KraftHudWindow _kraftHudWindow;
    private Rect _leftArea;
    private Rect _buttonsArea;
    private ButtonElement[] _buttons;
    private GUILayoutOption[] _buttonOptions;
    //private RectsData _rectsData;
    //private GUISkin _guiSkin;
    private int _icoSize;
    private int _maxSpaceFromEndIcon = 7; // Магическое число. Посчитано как (ButtonSizeWidth/ButtonSizeHeight - 1)==(256/32-1)
    //TODO del
    private void Start()
    {
        _kraftHudWindow = GetComponent<KraftHudWindow>();
        var gameDataContainer = GameDataContainer.Instance;
        //_rectsData = gameDataContainer.GetRectsData;
        //_guiSkin = gameDataContainer.StandartGuiSkin;
        //_buttonOptions = _rectsData.MainButtonsOption;
        //_leftArea = _rectsData.LeftArea;
        //_buttonsArea = _rectsData.ButtonsArea;
        //_icoSize = _rectsData.GetIcoSize;
        enabled = false;
    }

    public void Init(ButtonElement[] items, ButtonElement[] types, EquipTypes equipType)
    {
        _buttons = items;
        enabled = true;
    }

    public void Init(ButtonElement[] buttons)
    {
        _buttons = buttons;
        enabled = true;
    }

    private void OnGUI()
    {
        //GUI.skin = _guiSkin;
        ViewBackButton(_leftArea);
        ViewButtonList(_buttonsArea, _buttons);
    }

    private void ViewBackButton(Rect leftArea)
    {
        GUILayout.BeginArea(leftArea);
        if (GUILayout.Button("<"))
        {
            enabled = false;
            _kraftHudWindow.enabled = false;
            WindowManagement.Instance.MainHuds(true);
            new KraftTypesList().Init();
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
                _kraftHudWindow.Init(buttonElements[i].MainButton.CallbackParam);
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

                index = _maxSpaceFromEndIcon - index;
                GUILayout.Space(_icoSize * index);

                if (buttonElements[i].EndIcon != null)
                    ViewIcon(buttonElements[i].EndIcon);

                GUILayout.EndHorizontal();
            }

            if (buttonElements[i].AdditionalInfoBottom != null)
            {
                GUILayout.BeginHorizontal();
                GUILayout.Space(_icoSize);
                int index = 0;
                foreach (var item in buttonElements[i].AdditionalInfoBottom)
                {
                    ViewIcon(item);
                    index++;
                }
                GUILayout.EndHorizontal();
            }
        }
        GUILayout.EndArea();
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
