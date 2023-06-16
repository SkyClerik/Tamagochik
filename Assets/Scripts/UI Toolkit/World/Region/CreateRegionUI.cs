using Data.World;
using System.Collections.Generic;
using UnityEngine.UIElements;

namespace Hud.Buttons
{
    public class CreateRegionUI
    {
        private Region _region;
        private VisualElement _rootVisualElement;
        private ListView _buttonsListView;
        private List<Area> _areas;

        public CreateRegionUI(Region region)
        {
            _region = region;
            _areas = region.Areas;

            WindowManagement windowManagement = WindowManagement.Instance;
            UIDocument uiDocument = windowManagement.GetGeneralButtonsDoc;
            uiDocument.visualTreeAsset = windowManagement.VtaListButton;
            uiDocument.enabled = true;
            _rootVisualElement = uiDocument.rootVisualElement;

            GameDataContainer.Instance.GetWorldData.SetCurrentSelectNode = null;
            windowManagement.GetLocationInfoDoc.enabled = false;

            InitList(windowManagement.VtaGeneralButtonPattern);
            InitSlaveButtons();
        }

        private void InitList(VisualTreeAsset visualElementPattern)
        {
            List<ButtonContent> buttons = new List<ButtonContent>();
            for (int i = 0; i < _areas.Count; i++)
            {
                buttons.Add(new ButtonContent(_areas[i].ButtonText, _areas[i].Icon, _areas[i].Inside));
            }
            buttons.Add(new ButtonContent("to world", null, () => { _region.EntryBackList(); }));

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