namespace Hud.Buttons
{
    using UnityEngine;
    using UnityEngine.UIElements;

    public class StartDevelopSpace
    {
        public StartDevelopSpace()
        {
            WindowManagement windowManagement = WindowManagement.Instance;
            UIDocument uiDocument = windowManagement.GetGeneralButtons;
            uiDocument.visualTreeAsset = windowManagement.VtaDevelopSpace;
            uiDocument.enabled = true;

            VisualElement rootVisualElement = uiDocument.rootVisualElement;

            Button createButton = rootVisualElement.Q<Button>("CreateButton");
            Button unitsButton = rootVisualElement.Q<Button>("UnitsButton");
            Button roomsButton = rootVisualElement.Q<Button>("RoomsButton");
            Button dungeonsButton = rootVisualElement.Q<Button>("DungeonsButton");
            Button clickerButton = rootVisualElement.Q<Button>("ClickerButton");
            Button endDayButton = rootVisualElement.Q<Button>("EndDayButton");
            Button homeButton = rootVisualElement.Q<Button>("HomeButton");
            Button backButton = rootVisualElement.Q<Button>("BackButton");

            createButton.clicked += KraftTypesListButton;
            unitsButton.clicked += UnitsButton;
            roomsButton.clicked += RoomsButton;
            dungeonsButton.clicked += DungeonsButton;
            clickerButton.clicked += Clicker;
            endDayButton.clicked += EndTheDay;

            homeButton.visible = false;
            backButton.visible = false;
        }

        private void KraftTypesListButton()
        {
            Debug.Log($"Этот функционал еще в разработке");
            //new KraftTypesList().Init();
        }

        private void UnitsButton()
        {
            Debug.Log($"Этот функционал еще в разработке");
            //new Units().Init();
        }

        private void RoomsButton()
        {
            new StartRooms();
        }

        private void DungeonsButton()
        {
            Debug.Log($"Этот функционал еще в разработке");
            //new Dungeons().Init();
        }

        private void Clicker()
        {
            var windowManagement = WindowManagement.Instance;
            windowManagement.GetGeneralButtons.enabled = false;
            windowManagement.GetRightHud.enabled = false;
            new StartClicker();
            new StartInventory();
        }

        private void EndTheDay()
        {
            GameDataContainer.Instance.GetGameData.Day++;
        }
    }
}