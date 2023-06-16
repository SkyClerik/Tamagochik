using Data.World;
using System.Collections.Generic;
using UnityEngine.UIElements;

namespace Hud.Buttons
{
    public class CreateDistrictUI
    {
        private District _district;
        private VisualElement _rootVisualElement;
        private ListView _buttonsListView;
        private List<Shop> _shops;
        private List<House> _playerHouses;

        public CreateDistrictUI(District district)
        {
            _district = district;
            _shops = district.Shops;
            _playerHouses = district.GetPlayerHouses;

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
            for (int i = 0; i < _shops.Count; i++)
            {
                var shop = _shops[i];
                buttons.Add(new ButtonContent(shop.ButtonText, shop.Icon, shop.Inside));
            }
            for (int i = 0; i < _playerHouses.Count; i++)
            {
                var house = _playerHouses[i];
                buttons.Add(new ButtonContent(house.ButtonText, house.Icon, house.Inside));
            }
            buttons.Add(new ButtonContent("to town", null, _district.EntryBackList));

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