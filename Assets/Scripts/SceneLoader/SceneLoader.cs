using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField]
    private string _sceneName;
    public string SceneName { get => _sceneName; set => _sceneName = value; }

    [SerializeField]
    private LoadSceneMode _loadSceneMode;

    [SerializeField]
    private bool _launchAtStart = false;

    private void Start()
    {
        if (_launchAtStart == true)
            LoadSceneByDefault();
    }

    public void LoadSceneByDefault()
    {
        SceneManager.LoadSceneAsync(_sceneName, _loadSceneMode);
    }
}
