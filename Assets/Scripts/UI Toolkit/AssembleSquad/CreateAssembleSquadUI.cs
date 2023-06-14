using Data.Units;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CreateAssembleSquadUI
{
    private VisualElement _rootVisualElement;
    private ListView _buttonsListView;
    private List<Humanoid> _humanoids = new();
    private System.Action _closeAction;


    public CreateAssembleSquadUI(System.Action closeAction)
    {
        _closeAction = closeAction;

        WindowManagement windowManagement = WindowManagement.Instance;
        UIDocument uIDocument = windowManagement.GetAssembleSquadDoc;
        uIDocument.visualTreeAsset = windowManagement.VtaListButton;
        uIDocument.enabled = true;

        _rootVisualElement = uIDocument.rootVisualElement;

        GameDataContainer gameDataContainer = GameDataContainer.Instance;
        _humanoids = gameDataContainer.GetGameData.Master.Humanoids;

        InitSlaveButtons();
        InitList(windowManagement.VtaGeneralButtonPattern);
    }
    private void Hide()
    {
        WindowManagement windowManagement = WindowManagement.Instance;
        UIDocument uIDocument = windowManagement.GetAssembleSquadDoc;
        uIDocument.enabled = false;

        _closeAction?.Invoke();
    }

    private void FakeCallback()
    {
        Debug.Log($"FakeCallback");
    }

    private void InitList(VisualTreeAsset visualElementPattern)
    {
        List<ButtonContent> buttons = new List<ButtonContent>();
        for (int i = 0; i < _humanoids.Count; i++)
        {
            buttons.Add(new ButtonContent(_humanoids[i].Name, _humanoids[i].Icon, FakeCallback));
        }
        Debug.Log($"_humanoids.COUNT: {_humanoids.Count}");
        _buttonsListView = _rootVisualElement.Q<ListView>("List");
        _buttonsListView.makeItem = () => { return visualElementPattern.Instantiate(); };
        _buttonsListView.bindItem = (_item, _index) =>
        {
            ButtonContent item = buttons[_index];
            _item.Q<VisualElement>("Line2").style.display = DisplayStyle.None;
            _item.Q<VisualElement>("Icon").style.backgroundImage = new StyleBackground(item.Icon);
            Button button = _item.Q<Button>("MainButton");
            button.text = item.Title;
            button.clicked += () => { Debug.Log($"{item.Title}"); };
        };
        _buttonsListView.itemsSource = buttons;
    }

    private void InitSlaveButtons()
    {
        Button homeButton = _rootVisualElement.Q<Button>("HomeButton");
        homeButton.style.display = DisplayStyle.None;
        Button backButton = _rootVisualElement.Q<Button>("BackButton");
        backButton.style.display = DisplayStyle.Flex;
        backButton.clicked += Hide;
    }
}