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
        _startHouse.Inside();
        Destroy(gameObject);
    }
}