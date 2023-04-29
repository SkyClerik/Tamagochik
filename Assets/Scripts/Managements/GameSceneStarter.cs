using Hud.Buttons;
using UnityEngine;

public class GameSceneStarter : MonoBehaviour
{
    private GameDataContainer _gameDataContainer;

    private void Awake()
    {
        _gameDataContainer = GameDataContainer.Instance;
        _gameDataContainer.OnReady += Init;
        _gameDataContainer.Initialization();
    }

    private void Init()
    {
        _gameDataContainer.OnReady -= Init;
        Application.targetFrameRate = 60;
        new StartDevelopSpace();
        Destroy(gameObject);
    }
}