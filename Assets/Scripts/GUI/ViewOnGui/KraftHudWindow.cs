using Behaviours;
using Data.Items;
using Data.Recipes;
using Data.Rects;
using System.Collections.Generic;
using UnityEngine;

public class KraftHudWindow : MonoBehaviour
{
    private Rect _windowArea;
    private GUILayoutOption[] _buttonOptions;
    private RectsData _rectsData;
    private RecipesData _recipesData;
    private ItemsData _itemsData;
    private CustomItem _customItem;
    private GameDataContainer _gameDataContainer;
    private GUISkin _guiSkin;
    private GUIStyle _buttonActive;
    private GUIStyle _buttonLock;
    private GUIStyle _iconStyle;
    private int _icoSize;
    private const string _leftButtonStyle = "leftButton";
    private const string _lockButtonStyle = "lockButton";
    private const string _onlyIcon = "onlyIcon";
    private GUIContent _windowContent = new GUIContent("Info window");
    private List<DemandResult>[] demandResultsList;
    private List<ButtonElement> _demandsIcons;
    private int _coast = 0;

    private void Start()
    {
        var gameDataContainer = GameDataContainer.Instance;
        _itemsData = gameDataContainer.GetItemsData;
        _rectsData = gameDataContainer.GetRectsData;
        _recipesData = gameDataContainer.GetRecipesData;
        _guiSkin = gameDataContainer.StandartGuiSkin;
        _buttonOptions = _rectsData.MainButtonsOption;
        _windowArea = _rectsData.KraftWindowArea;
        enabled = false;
    }

    public void Init(int itemIndex)
    {
        _gameDataContainer = GameDataContainer.Instance;
        _guiSkin = _gameDataContainer.StandartGuiSkin;
        _buttonActive = _guiSkin.GetStyle($"{_leftButtonStyle}");
        _buttonLock = _guiSkin.GetStyle($"{_lockButtonStyle}");
        _iconStyle = _guiSkin.GetStyle($"{_onlyIcon}");
        _icoSize = _rectsData.GetIcoSize;

        //try
        //{
        _customItem = _itemsData.Items[itemIndex];
        _windowContent.text = _customItem.Name;
        Texture texture = TextureConverter.SpriteToTexture(_customItem.Icon);
        _windowContent.image = texture;
        GetRecipes();
        enabled = true;
        //}
        //catch
        //{
        //    Debug.Log($"{GameDataContainer.Instance.GetHudTextData.MasterSeemsToBeProblemHere}");
        //}
    }

    private void GetRecipes()
    {
        if (_customItem.RecipesIndex.Count > 0)
        {
            demandResultsList = new List<DemandResult>[_customItem.RecipesIndex.Count];
            _demandsIcons = new List<ButtonElement>();
            foreach (int recipeIndex in _customItem.RecipesIndex)
            {
                for (int i = 0; i < demandResultsList.Length; i++)
                {
                    demandResultsList[i] = _recipesData.Recipes[recipeIndex].GetItemBase();
                    _coast += _recipesData.Recipes[recipeIndex].Coast;

                    foreach (DemandResult result in demandResultsList[i])
                    {
                        _demandsIcons.Add(new ButtonElement(
                            mainIcon: new IconElement(new GUIContent(TextureConverter.SpriteToTexture(result.ItemBase.Icon)), _iconStyle),
                            mainButton: new ViewElementButton(
                            buttonText: result.Amount.ToString(),
                            callback: null,
                            style: _buttonActive,
                            active: true),
                            additionalInfo: null,
                            endIcon: null)
                            );
                    }
                }
            }
        }
    }

    private void OnGUI()
    {
        GUI.skin = _guiSkin;
        GUI.Window(0, _windowArea, View, _windowContent);
    }

    private void View(int w)
    {
        GUILayout.Box($"Текущее количество: {_customItem.Amount}");
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
            _customItem.Amount++;
            //TODO Вот тут нужно удалить все что было использовано для крафта. И крафт не мгновенный должен быть. Куда поместить текущий? От пошаговости еще не время отказываться.
        }
    }

    private void ViewIcon(IconElement iconElement)
    {
        GUILayout.Box(iconElement.Content.image, iconElement.GUIStyle, GUILayout.Width(_icoSize), GUILayout.Height(_icoSize));
    }
}
