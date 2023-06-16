using Data.World;
using System.Collections.Generic;
using UnityEngine.UIElements;

namespace Hud.Buttons
{
    public class CreateAreaUI
    {
        private Area _area;
        private VisualElement _rootVisualElement;
        private ListView _buttonsListView;
        private List<Town> _towns;
        private List<Dungeon> _dungeons;

        public CreateAreaUI(Area area)
        {
            _area = area;
            _towns = area.Towns;
            _dungeons = area.Dungeons;

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
            for (int i = 0; i < _towns.Count; i++)
            {
                buttons.Add(new ButtonContent(_towns[i].ButtonText, _towns[i].Icon, _towns[i].Inside));
            }
            for (int i = 0; i < _dungeons.Count; i++)
            {
                buttons.Add(new ButtonContent(_dungeons[i].ButtonText, _dungeons[i].Icon, _dungeons[i].Inside));
            }
            buttons.Add(new ButtonContent("to region", null, () => { _area.EntryBackList(); }));


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