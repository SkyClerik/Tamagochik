using Data.World;
using UnityEngine;

public class GameSceneStarter : MonoBehaviour
{
    private GameDataContainer _gameDataContainer;

    [SerializeField]
    private House _startHouse;

    private void Awake()
    {
        _gameDataContainer = GameDataContainer.Instance;
        _gameDataContainer.OnReady += Init;
        _gameDataContainer.Initialization();
    }

    private void Init()
    {
        _gameDataContainer.OnReady -= Init;
        //Application.targetFrameRate = 60;
        SetMaster();
        _startHouse.BuyForce();
        _startHouse.StartForced();
    }

    void SetMaster()
    {
        GameDataContainer gameDataContainer = GameDataContainer.Instance;
        UnitsData unitsData = gameDataContainer.GetUnitsData;
        GameData gameData = gameDataContainer.GetGameData;

        var randomValue = Random.Range(0, unitsData.MasterList.Count);
        gameData.Master = unitsData.GetMasterClone(randomValue);
    }
}