using UnityEngine;
using Data.Item;
using Data.Storages;
using Data.Recipes;
using Data.World;

public class GameDataContainer : Singleton<GameDataContainer>
{
    [Header("Не клонируемые")]

    [SerializeField]
    private SpriteData _spriteData;
    public SpriteData GetSpriteData => _spriteData;

    [SerializeField]
    private HudTextData _hudTextData;
    public HudTextData GetHudTextData => _hudTextData;

    [SerializeField]
    private UnitsData _unitsData;
    public UnitsData GetUnitsData => _unitsData;

    [SerializeField]
    private WorldData _worldData;
    public WorldData GetWorldData => _worldData;

    [Header("Клонируемые")]

    [SerializeField]
    private GameData _gameData;
    public GameData GetGameData => _gameData;

    [SerializeField]
    private GameSettingsData _gameSettingsData;
    public GameSettingsData GetGameSettingsData => _gameSettingsData;

    [SerializeField]
    private ItemsData _itemsData;
    public ItemsData GetItemsData => _itemsData;

    [SerializeField]
    private StoragesData _storagesData;
    public StoragesData GetStoragesData => _storagesData;

    [SerializeField]
    private RecipesData _recipesData;
    public RecipesData GetRecipesData => _recipesData;


    public event System.Action OnReady;

    public void Initialization()
    {
        if (_gameData)
            _gameData = Instantiate(_gameData);

        if (_gameSettingsData)
            _gameSettingsData = Instantiate(_gameSettingsData);

        if (_itemsData)
            _itemsData = Instantiate(_itemsData);

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
