using UnityEngine;

[RequireComponent(typeof(SceneLoader))]
public class GameMenu : MonoBehaviour
{
    private Rect _windowArea;
    [SerializeField]
    private SceneLoader _loadSceneManager;
    private bool _view = false;

    private void OnValidate()
    {
        _loadSceneManager = GetComponent<SceneLoader>();
    }

    private void Start()
    {
        var gameDataContainer = GameDataContainer.Instance;
        _windowArea = gameDataContainer.GetRectsData.KraftWindowArea;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            _view = !_view;
        }
    }

    private void OnGUI()
    {
        if (_view)
        {
            GUILayout.BeginArea(_windowArea);

            if (GUILayout.Button("Main Menu"))
            {
                _loadSceneManager.LoadSceneByDefault();
            }

            if (GUILayout.Button("Close Game"))
            {
                Application.Quit();
            }

            GUILayout.EndArea();
        }
    }
}
