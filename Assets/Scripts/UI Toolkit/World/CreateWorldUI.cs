using Data.World;
using System.Collections.Generic;
using UnityEngine.UIElements;

namespace Hud.Buttons
{
    public class CreateWorldUI
    {
        private VisualElement _rootVisualElement;
        private ListView _buttonsListView;
        private List<Region> _regions;

        public CreateWorldUI(WorldData worldData)
        {
            _regions = worldData.Regions;

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
            List<ButtonContent> buttons = new List<ButtonContent>();
            for (int i = 0; i < _regions.Count; i++)
            {
                buttons.Add(new ButtonContent(_regions[i].ButtonText, _regions[i].Icon, _regions[i].Inside));
            }

            _buttonsListView = _rootVisualElement.Q<ListView>("List");
            _buttonsListView.makeItem = () => { return visualElementPattern.Instantiate(); };
            _buttonsListView.bindItem = (_item, _index) =>
            {
                var item = buttons[_index];
                _item.Q<VisualElement>("Line2").style.display = DisplayStyle.None;
                _item.Q<VisualElement>("Icon").style.backgroundImage = new StyleBackground(item.Icon);
                Button button = _item.Q<Button>("MainButton");
                button.text = item.Title;
                button.clicked += item.Clicked;
            };

            _buttonsListView.itemsSource = buttons;
        }

        private void InitSlaveButtons()
        {
            Button homeButton = _rootVisualElement.Q<Button>("HomeButton");
            homeButton.style.display = DisplayStyle.None;
            Button backButton = _rootVisualElement.Q<Button>("BackButton");
            backButton.style.display = DisplayStyle.None;
        }
    }
}