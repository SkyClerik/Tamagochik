using UnityEngine;
using Data.Dungeon;
using Data.Items;
using Data.Rects;
using Data.Resources;
using Data.Storages;
using Data.Recipes;

public class GameDataContainer : Singleton<GameDataContainer>
{
    [Header("Не клонируемые")]

    [SerializeField]
    private GUISkin _standartGuiSkin;
    public GUISkin StandartGuiSkin => _standartGuiSkin;

    [SerializeField]
    private HudIconData _hudIconData;
    public HudIconData GetHudIconData => _hudIconData;

    [SerializeField]
    private HudTextData _hudTextData;
    public HudTextData GetHudTextData => _hudTextData;

    [SerializeField]
    private UnitsData _unitsData;
    public UnitsData GetUnitsData => _unitsData;

    [Header("Клонируемые")]

    [SerializeField]
    private RectsData _rectsData;
    public RectsData GetRectsData => _rectsData;

    [SerializeField]
    private GameData _gameData;
    public GameData GetGameData => _gameData;

    [SerializeField]
    private PersonalSpace _shopData;
    public PersonalSpace GetShopData => _shopData;

    [SerializeField]
    private GameSettingsData _gameSettingsData;
    public GameSettingsData GetGameSettingsData => _gameSettingsData;

    [SerializeField]
    private DungeonsData _dungeonsData;
    public DungeonsData GetDungeonsData => _dungeonsData;

    [SerializeField]
    private ItemsData _itemsData;
    public ItemsData GetItemsData => _itemsData;

    [SerializeField]
    private ResourcesData _resourcesData;
    public ResourcesData GetResourcesData => _resourcesData;

    [SerializeField]
    private StoragesData _storagesData;
    public StoragesData GetStoragesData => _storagesData;

    [SerializeField]
    private RecipesData _recipesData;
    public RecipesData GetRecipesData => _recipesData;

    public event System.Action OnReady;

    public void Initialization()
    {
        if (_rectsData)
        {
            _rectsData = Instantiate(_rectsData);
            _rectsData.Init();
        }

        if (_gameData)
            _gameData = Instantiate(_gameData);

        if (_gameSettingsData)
            _gameSettingsData = Instantiate(_gameSettingsData);

        if (_shopData)
            _shopData = Instantiate(_shopData);

        if (_shopData)
            _shopData = Instantiate(_shopData);

        if (_dungeonsData)
            _dungeonsData = Instantiate(_dungeonsData);

        if (_itemsData)
            _itemsData = Instantiate(_itemsData);

        if (_resourcesData)
            _resourcesData = Instantiate(_resourcesData);

        if (_storagesData)
            _storagesData = Instantiate(_storagesData);

        if (_recipesData)
            _recipesData = Instantiate(_recipesData);


        var randomValue = Random.Range(0, _unitsData.MasterList.Count);
        _gameData.Master = _unitsData.GetMasterDeepCopy(randomValue);

        Ready();
    }

    public void Ready()
    {
        OnReady?.Invoke();
    }
}
