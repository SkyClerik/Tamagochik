using Data.Item;
using Data.Recipes;
using System.Collections.Generic;
using UnityEngine;

public class KraftHudWindow : MonoBehaviour
{
    private Rect _windowArea;
    private GUILayoutOption[] _buttonOptions;
    //private RectsData _rectsData;
    private RecipesData _recipesData;
    private ItemsData _itemsData;
    private ItemBase _itemBase;
    private GameDataContainer _gameDataContainer;
    //private GUISkin _guiSkin;
    private GUIStyle _buttonActive;
    private GUIStyle _buttonLock;
    private GUIStyle _iconStyle;
    private int _icoSize;
    private const string _leftButtonStyle = "leftButton";
    private const string _lockButtonStyle = "lockButton";
    private const string _onlyIcon = "onlyIcon";
    private GUIContent _windowContent = new GUIContent("Info window");
    private List<ItemInQuantity>[] demands;
    private List<ButtonElement> _demandsIcons;
    private int _coast = 0;
    //TODO del
    private void Start()
    {
        var gameDataContainer = GameDataContainer.Instance;
        _itemsData = gameDataContainer.GetItemsData;
        //_rectsData = gameDataContainer.GetRectsData;
        _recipesData = gameDataContainer.GetRecipesData;
        //_guiSkin = gameDataContainer.StandartGuiSkin;
        //_buttonOptions = _rectsData.MainButtonsOption;
        //_windowArea = _rectsData.KraftWindowArea;
        enabled = false;
    }

    public void Init(int itemIndex)
    {
        _gameDataContainer = GameDataContainer.Instance;
        //_guiSkin = _gameDataContainer.StandartGuiSkin;
        //_buttonActive = _guiSkin.GetStyle($"{_leftButtonStyle}");
        //_buttonLock = _guiSkin.GetStyle($"{_lockButtonStyle}");
        //_iconStyle = _guiSkin.GetStyle($"{_onlyIcon}");
        //_icoSize = _rectsData.GetIcoSize;
        _itemBase = _itemsData.Items[itemIndex];
        _windowContent.text = _itemBase.Name;
        Texture texture = TextureConverter.SpriteToTexture(_itemBase.Icon);
        _windowContent.image = texture;
        GetRecipes();
        enabled = true;
    }

    private void GetRecipes()
    {
        //if (_itemBase.RecipesIndex.Count > 0)
        //{
        //    demands = new List<Demand>[_itemBase.RecipesIndex.Count];
        //    _demandsIcons = new List<ButtonElement>();
        //    foreach (int recipeIndex in _itemBase.RecipesIndex)
        //    {
        //        for (int i = 0; i < demands.Length; i++)
        //        {
        //            demands[i] = _recipesData.Recipes[recipeIndex].GetItemBase();
        //            _coast += _recipesData.Recipes[recipeIndex].Coast;

        //            foreach (Demand result in demands[i])
        //            {
        //                _demandsIcons.Add(new ButtonElement(
        //                    mainIcon: new IconElement(new GUIContent(TextureConverter.SpriteToTexture(result.ItemBase.Icon)), _iconStyle),
        //                    mainButton: new ViewElementButton(
        //                    buttonText: result.Amount.ToString(),
        //                    callback: null,
        //                    style: _buttonActive,
        //                    active: true),
        //                    additionalInfo: null,
        //                    endIcon: null)
        //                    );
        //            }
        //        }
        //    }
        //}
    }

    private void OnGUI()
    {
        //GUI.skin = _guiSkin;
        GUI.Window(0, _windowArea, View, _windowContent);
    }

    private void View(int w)
    {
        GUILayout.Box($"Текущее количество: {_itemBase.Amount}");
        GUILayout.Box($"Стоймость крафта: {_coast}");

        for (int i = 0; i < _demandsIcons.Count; i++)
        {
            GUILayout.BeginHorizontal();
            ViewIcon(_demandsIcons[i].MainIcon);
            GUILayout.Box(_demandsIcons[i].MainButton.ButtonText, _demandsIcons[i].MainButton.Style, _buttonOptions);
            GUILayout.EndHorizontal();
        }

        if (GUILayout.Button("Создать"))
        {
            _itemBase.Amount++;
        }
    }

    private void ViewIcon(IconElement iconElement)
    {
        GUILayout.Box(iconElement.Content.image, iconElement.GUIStyle, GUILayout.Width(_icoSize), GUILayout.Height(_icoSize));
    }
}
