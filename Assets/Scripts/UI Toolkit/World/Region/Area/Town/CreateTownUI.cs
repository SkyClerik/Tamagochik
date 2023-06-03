using Data.World;
using System.Collections.Generic;
using UnityEngine.UIElements;

namespace Hud.Buttons
{
    public class CreateTownUI
    {
        private Town _town;
        private VisualElement _rootVisualElement;
        private ListView _buttonsListView;
        private List<District> _districts;

        public CreateTownUI(Town town)
        {
            _town = town;
            _districts = town.Districts;

            WindowManagement windowManagement = WindowManagement.Instance;
            UIDocument uiDocument = windowManagement.GetGeneralButtons;
            uiDocument.visualTreeAsset = windowManagement.VtaListButton;
            uiDocument.enabled = true;
            _rootVisualElement = uiDocument.rootVisualElement;

            windowManagement.CurrentSelectNode = null;
            windowManagement.GetLocationInfo.enabled = false;

            InitList(windowManagement.VtaGeneralButtonPattern);
            InitSlaveButtons();
        }

        private void InitList(VisualTreeAsset visualElementPattern)
        {
            List<ButtonContent> buttons = new List<ButtonContent>();
            for (int i = 0; i < _districts.Count; i++)
            {
                buttons.Add(new ButtonContent(_districts[i].ButtonText, _districts[i].Icon, _districts[i].Inside));
            }
            buttons.Add(new ButtonContent("to area", null, () => { _town.Outside(); }));


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