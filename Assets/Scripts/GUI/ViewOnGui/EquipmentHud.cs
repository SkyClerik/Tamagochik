using Data.Item;
using Data.Units;
using Hud.Buttons;
using System;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentHud : MonoBehaviour
{
    private Rect _leftArea;
    private Rect _buttonsArea;

    private Action _backToAction;
    private ButtonElement[] _euipmentButtons;
    private GUILayoutOption[] _buttonOptions;
    private Humanoid _unitHumanoid;
    private ItemsData _itemsData;

    private GUISkin _guiSkin;
    private GUIStyle _buttonActive;
    private GUIStyle _buttonLock;
    private GUIStyle _iconStyle;
    private const string _leftButtonStyle = "leftButton";
    private const string _lockButtonStyle = "lockButton";
    private const string _onlyIcon = "onlyIcon";
    private int _maxSpaceFromEndIcon = 7; // Магическое число. Посчитано как (ButtonSizeWidth/ButtonSizeHeight - 1)==(256/32-1)
    private int _icoSize;
    //TODO del
    private void Start()
    {
        var gameDataContainer = GameDataContainer.Instance;
        _itemsData = gameDataContainer.GetItemsData;
        //RectsData rectsData = gameDataContainer.GetRectsData;
        //_icoSize = rectsData.GetIcoSize;
        //_buttonOptions = rectsData.MainButtonsOption;
        //_leftArea = rectsData.LeftArea;
        //_buttonsArea = rectsData.ButtonsArea;
        //_windowArea = rectsData.KraftWindowArea;
        //_guiSkin = gameDataContainer.StandartGuiSkin;
        _buttonActive = _guiSkin.GetStyle($"{_leftButtonStyle}");
        _buttonLock = _guiSkin.GetStyle($"{_lockButtonStyle}");
        _iconStyle = _guiSkin.GetStyle($"{_onlyIcon}");
        enabled = false;
    }

    public void Init(Humanoid humanoid)
    {
        _unitHumanoid = humanoid;
        _backToAction = BackButton;
        RegistredSlotTypes();
        enabled = true;
    }

    private void BackButton()
    {
        WindowManagement windowManagement = WindowManagement.Instance;
        windowManagement.GetEquipmentHud.enabled = false;
        windowManagement.MainHuds(true);

        new UnitInfo().Init(_unitHumanoid);
    }

    private void Init(EquipTypes equipType)
    {
        CreateItemButtons(equipType);
    }

    private void RegistredSlotTypes()
    {
        _euipmentButtons = new ButtonElement[]
        {
            CreateSlotButton("Голова", EquipTypes.Head),
            CreateSlotButton("Левая рука", EquipTypes.LeftArm),
            CreateSlotButton("Правая рука", EquipTypes.RightArm),
            CreateSlotButton("Торс", EquipTypes.Torso),
            CreateSlotButton("Обувь", EquipTypes.Feet),
        };
    }

    private ButtonElement CreateSlotButton(string buttonName, EquipTypes equipTypes)
    {
        for (int i = 0; i < _unitHumanoid.Eqiupments?.Length; i++)
        {
            if (_unitHumanoid.Eqiupments[i].Id >= 0 && _unitHumanoid.Eqiupments[i].GetEquipType == equipTypes)
                return CreateItemButton(_unitHumanoid.Eqiupments[i], () => { Init(equipTypes); });
        }

        return new ButtonElement(
            mainIcon: new IconElement(new GUIContent(string.Empty), _iconStyle),
            mainButton: new ViewElementButton(
                buttonText: buttonName,
                callback: () => { Init(equipTypes); },
                style: _buttonActive,
                active: true),
            additionalInfo: null,
            endIcon: null);
    }

    private void CreateItemButtons(EquipTypes equipType)
    {
        List<ButtonElement> euipmentButtons = new List<ButtonElement>();
        var readyButtons = 0;
        for (int i = 0; i < _itemsData.Items.Count; i++)
        {
            if (_itemsData.Items[i] is not EquipmentItem)
                continue;

            var item = _itemsData.Items[i] as EquipmentItem;

            int equipIndex = _unitHumanoid.GetEquipIndex(equipType);
            if (_unitHumanoid.Eqiupments[equipIndex] == item)
                continue;

            if (item.Amount <= 0)
                continue;

            if (item.GetEquipType == equipType)
            {
                euipmentButtons.Add(CreateItemButton(_itemsData.Items[i], EquipItem, i));
                readyButtons++;
            }
        }

        if (readyButtons == 0)
        {
            RegistredSlotTypes();
            return;
        }

        _euipmentButtons = euipmentButtons.ToArray();
    }

    private void EquipItem(int index)
    {
        TryPutAwayItemToWarehouse(index);

        var item = _itemsData.Items[index] as EquipmentItem;
        item = Instantiate(item);
        _unitHumanoid.EquipItem(item);
        _itemsData.Items[index].Amount--;
        RegistredSlotTypes();
    }

    public void TryPutAwayItemToWarehouse(int index)
    {
        var item = _itemsData.Items[index] as EquipmentItem;
        int equipIndex = _unitHumanoid.GetEquipIndex(item.GetEquipType);
        if (_unitHumanoid.Eqiupments[equipIndex].Id >= 0)
        {
            for (int i = 0; i < _itemsData.Items.Count; i++)
            {
                if (_itemsData.Items[i].Id == _unitHumanoid.Eqiupments[equipIndex].Id)
                {
                    _itemsData.Items[i].Amount++;
                    break;
                }
            }
        }
    }

    private ButtonElement CreateItemButton(ItemBase itemBase, Action action)
    {
        Texture2D itemIcon = TextureConverter.SpriteToTexture(itemBase.Icon);

        return new ButtonElement(
            mainIcon: new IconElement(new GUIContent(itemIcon), _iconStyle),
            mainButton: new ViewElementButton(
                buttonText: itemBase.Name,
                callback: action,
                style: _buttonActive,
                active: true),
            additionalInfo: null,
            endIcon: null);
    }

    private ButtonElement CreateItemButton(ItemBase itemBase, Action<int> action, int index)
    {
        Texture2D itemIcon = TextureConverter.SpriteToTexture(itemBase.Icon);

        return new ButtonElement(
            mainIcon: new IconElement(new GUIContent(itemIcon), _iconStyle),
            mainButton: new ViewElementButton(
                buttonText: itemBase.Name,
                callbackInt: action,
                callbackParam: index,
                style: _buttonActive,
                active: true),
            additionalInfo: null,
            endIcon: null);
    }

    private void OnGUI()
    {
        GUI.skin = _guiSkin;

        try
        {
            ViewBackButton(_leftArea);
            ViewButtonList(_buttonsArea);
        }
        catch
        {
            //Nothing
        }
    }

    private void ViewBackButton(Rect leftArea)
    {
        GUILayout.BeginArea(leftArea);
        if (_backToAction != null)
        {
            if (GUILayout.Button("<"))
            {
                _backToAction.Invoke();
            }
        }
        GUILayout.EndArea();
    }

    private void ViewButtonList(Rect buttonsArea)
    {
        GUILayout.BeginArea(buttonsArea);
        for (int i = 0; i < _euipmentButtons?.Length; i++)
        {
            GUILayout.BeginHorizontal();
            ViewIcon(_euipmentButtons[i].MainIcon);
            if (GUILayout.Button(_euipmentButtons[i].MainButton.ButtonText, _euipmentButtons[i].MainButton.Style, _buttonOptions))
            {
                if (_euipmentButtons[i].MainButton.Active)
                {
                    _euipmentButtons[i].MainButton.Invoke();
                }
            }
            GUILayout.EndHorizontal();

            if (_euipmentButtons[i].AdditionalInfo != null)
            {
                GUILayout.BeginHorizontal();
                GUILayout.Space(_icoSize);
                int index = 0;
                foreach (var item in _euipmentButtons[i].AdditionalInfo)
                {
                    ViewIcon(item);
                    index++;
                }

                index = Mathf.Abs(_maxSpaceFromEndIcon - index);
                GUILayout.Space(_icoSize * index);

                if (_euipmentButtons[i].EndIcon != null)
                {
                    ViewIcon(_euipmentButtons[i].EndIcon);
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