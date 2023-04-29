using UnityEngine;
using UnityEngine.UIElements;

[RequireComponent(typeof(SceneLoader), typeof(UIDocument))]
public class MainMenu : MonoBehaviour
{
    [SerializeField]
    private SceneLoader _loadSceneManager;

    private VisualElement _firstList;
    private VisualElement _secondList;

    private void OnValidate()
    {
        _loadSceneManager = GetComponent<SceneLoader>();
    }

    private void Awake()
    {
        UIDocument uiDocument = GetComponent<UIDocument>();

        VisualElement rootVisualElement = uiDocument.rootVisualElement;

        _firstList = rootVisualElement.Q<VisualElement>("FirstList");
        _secondList = rootVisualElement.Q<VisualElement>("SecondList");
        _firstList.style.display = DisplayStyle.Flex;
        _secondList.style.display = DisplayStyle.None;

        Button playButton = _firstList.Q<Button>("PlayButton");
        Button settingsButton = _firstList.Q<Button>("SettingsButton");
        Button authorsButton = _firstList.Q<Button>("AuthorsButton");
        Button exitButton = _firstList.Q<Button>("ExitButton");

        Button newGameButton = _secondList.Q<Button>("NewGameButton");
        Button loadGameButton = _secondList.Q<Button>("LoadGameButton");
        Button backButton = _secondList.Q<Button>("BackButton");

        playButton.clicked += ClickPlayButton;
        settingsButton.clicked += ClickSettingsButton;
        authorsButton.clicked += ClickAuthorsButton;
        exitButton.clicked += ClickExitButton;

        newGameButton.clicked += ClickNewGameButton;
        loadGameButton.clicked += ClickLoadGameButton;
        backButton.clicked += ClickBackButton;
    }

    private void ClickPlayButton()
    {
        _firstList.style.display = DisplayStyle.None;
        _secondList.style.display = DisplayStyle.Flex;
    }

    private void ClickSettingsButton()
    {
    }

    private void ClickAuthorsButton()
    {
    }

    private void ClickExitButton()
    {
        Application.Quit();
    }

    private void ClickNewGameButton()
    {
        _loadSceneManager.LoadSceneByDefault();
    }

    private void ClickLoadGameButton()
    {
    }

    private void ClickBackButton()
    {
        _firstList.style.display = DisplayStyle.Flex;
        _secondList.style.display = DisplayStyle.None;
    }
}