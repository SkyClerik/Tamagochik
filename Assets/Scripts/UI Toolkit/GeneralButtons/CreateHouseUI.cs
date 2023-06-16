using Data.World;
using UnityEngine;
using UnityEngine.UIElements;

namespace Hud.Buttons
{
    public class CreateHouseUI
    {
        private House _house;
        private CreateInventoryUI _inventory;
        private CreateWarehouseUI _warehouse;

        public CreateHouseUI(House house)
        {
            _house = house;

            WindowManagement windowManagement = WindowManagement.Instance;
            UIDocument uiDocument = windowManagement.GetGeneralButtonsDoc;
            uiDocument.visualTreeAsset = windowManagement.VtaDevelopSpace;
            uiDocument.enabled = true;

            GameDataContainer.Instance.GetWorldData.SetCurrentSelectNode = null;
            windowManagement.GetLocationInfoDoc.enabled = false;

            VisualElement rootVisualElement = uiDocument.rootVisualElement;

            Button createButton = rootVisualElement.Q<Button>("CreateButton");
            Button unitsButton = rootVisualElement.Q<Button>("UnitsButton");
            Button roomsButton = rootVisualElement.Q<Button>("RoomsButton");
            Button endDayButton = rootVisualElement.Q<Button>("EndDayButton");
            Button warehouseButton = rootVisualElement.Q<Button>("WarehouseButton");
            Button leaveHouse = rootVisualElement.Q<Button>("LeaveHouse");

            Button homeButton = rootVisualElement.Q<Button>("HomeButton");
            Button backButton = rootVisualElement.Q<Button>("BackButton");

            createButton.clicked += KraftTypesListButton;
            unitsButton.clicked += AssembleSquad;
            roomsButton.clicked += RoomsButton;
            endDayButton.clicked += EndTheDay;
            warehouseButton.clicked += Warehouse;
            leaveHouse.clicked += LeaveHouse;

            homeButton.visible = false;
            backButton.visible = false;
        }

        private void KraftTypesListButton()
        {
            Debug.Log($"Этот функционал еще в разработке");
            //new KraftTypesList().Init();
        }

        private void AssembleSquad()
        {
            //new Units().Init();
            Hide();
            new CreateAssembleSquadUI(CloseAssembleSquad);
        }

        private void CloseAssembleSquad()
        {
            _house.StartForced();
        }

        private void RoomsButton()
        {
            new StartRooms();
        }

        private void EndTheDay()
        {
            GameDataContainer.Instance.GetGameData.Day++;
        }

        private void Warehouse()
        {
            Hide();
            _inventory = new CreateInventoryUI();
            _warehouse = new CreateWarehouseUI(CloseWarehouse);
        }

        private void CloseWarehouse()
        {
            _inventory.Hide();
            _warehouse.Hide();
            _house.StartForced();
        }

        private void LeaveHouse()
        {
            Debug.Log($"Выйти из дома");
            Hide();
            _house.Outside();
        }

        private void Hide()
        { 
            var windowManagement = WindowManagement.Instance;
            windowManagement.GetGeneralButtonsDoc.enabled = false;
            windowManagement.GetRightDoc.enabled = false;
        }
    }
}