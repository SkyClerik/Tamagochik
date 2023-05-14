namespace Hud.Buttons
{
    using Behaviours;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.UIElements;

    public class StartRooms
    {
        private GameDataContainer _gameDataContainer;
        private VisualElement _rootVisualElement;
        private ListView _buttonsListView;
        private List<StorageBase> _storages;

        public StartRooms()
        {
            _gameDataContainer = GameDataContainer.Instance;
            _storages = _gameDataContainer.GetStoragesData.Storages;

            WindowManagement windowManagement = WindowManagement.Instance;
            UIDocument uiDocument = windowManagement.GetGeneralButtons;
            uiDocument.visualTreeAsset = windowManagement.VtaListButton;
            uiDocument.enabled = true;
            _rootVisualElement = uiDocument.rootVisualElement;

            InitList(windowManagement.VtaGeneralButtonPattern);
            InitSlaveButtons();
        }

        private void InitList(VisualTreeAsset visualElementPattern)
        {
            _buttonsListView = _rootVisualElement.Q<ListView>("List");
            _buttonsListView.makeItem = () => { return visualElementPattern.Instantiate(); };
            _buttonsListView.bindItem = (_item, _index) =>
            {
                StorageBase item = _storages[_index];
                _item.Q<VisualElement>("Line2").style.display = DisplayStyle.None;
                _item.Q<VisualElement>("Icon").style.backgroundImage = new StyleBackground(item.Icon);
                Button button = _item.Q<Button>("MainButton");
                button.text = item.Name;
                button.clicked += () => { Debug.Log($"{item.Name}"); };
            };
            _buttonsListView.itemsSource = _storages;
        }

        private void InitSlaveButtons()
        {
            Button homeButton = _rootVisualElement.Q<Button>("HomeButton");
            homeButton.style.display = DisplayStyle.None;
            Button backButton = _rootVisualElement.Q<Button>("BackButton");
            backButton.style.display = DisplayStyle.Flex;
            backButton.clicked += BackButton;
        }

        private void BackButton()
        {
            //new StartDevelopSpace();
        }
    }
}