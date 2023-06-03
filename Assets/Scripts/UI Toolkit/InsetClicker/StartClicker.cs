using Data.Item;
using Data.Units;
using Data.World;
using UnityEngine;
using UnityEngine.UIElements;

public class StartClicker
{
    private GameDataContainer _gameDataContainer;
    private Dungeon _dungeon;

    private Humanoid _humanoid;
    private ItemBase[] _lutList;

    private float _lineMaxValue = 242; //TODO погуглить как получить размер

    private float _stepLineA = 6;
    private float _attackLineValue;

    private float _stepLineB = 20;
    private float _protectLineValue;

    private VisualElement _attackLine;
    private VisualElement _protectLine;

    public StartClicker(Dungeon dungeon)
    {
        _gameDataContainer = GameDataContainer.Instance;
        _dungeon = dungeon;

        WindowManagement windowManagement = WindowManagement.Instance;
        UIDocument uiDocument = windowManagement.GetClickerHud;
        uiDocument.enabled = true;

        windowManagement.GetGeneralButtons.enabled = false;
        windowManagement.GetLocationInfo.enabled = false;

        VisualElement rootVisualElement = uiDocument.rootVisualElement;

        _attackLine = rootVisualElement.Q<VisualElement>("AttackLine");
        _protectLine = rootVisualElement.Q<VisualElement>("ProtectLine");

        Button theOneButton = rootVisualElement.Q<Button>("TheOneButton");
        Button attackButton = rootVisualElement.Q<Button>("AttackButton");
        theOneButton.clicked += ButtonClicked;
        attackButton.clicked += AttackButtonClicked;

        Button homeButton = rootVisualElement.Q<Button>("HomeButton");
        Button backButton = rootVisualElement.Q<Button>("BackButton");
        homeButton.visible = true;
        backButton.visible = false;
        homeButton.clicked += BackButton;

        ResetParams(ref attackButton);
        GenerateLutList();

        new StartInventory();
    }

    private void ResetParams(ref Button button)
    {
        _humanoid = _gameDataContainer.GetGameData.Master;
        _attackLineValue = 0f;
        _protectLineValue = 0f;
    }

    private void GenerateLutList()
    {
        _lutList = new ItemBase[3];
        for (int i = 0; i < _lutList.Length; i++)
        {
            _lutList[i] = _gameDataContainer.GetItemsData.Items[i];
        }
    }

    private void BackButton()
    {
        var windowManagement = WindowManagement.Instance;
        windowManagement.GetInventoryHud.enabled = false;
        windowManagement.GetGeneralButtons.enabled = true;

        UIDocument uiDocument = windowManagement.GetClickerHud;
        uiDocument.enabled = false;

        _dungeon.Outside();
    }

    private void AddRandomItem()
    {
        _attackLineValue = 0;

        var randomValue = Random.Range(0, _lutList.Length);
        _humanoid.Inventory.AddItem(_lutList[randomValue]);
    }

    private void ButtonClicked()
    {
        _attackLineValue += _stepLineA;

        _protectLineValue += _stepLineB;
        if (_protectLineValue > _lineMaxValue)
            _protectLineValue = _lineMaxValue;

        if (_attackLineValue >= _lineMaxValue)
            AddRandomItem();

        UpdateAttackLine();
        UpdateProtectLine();
    }

    private void AttackButtonClicked()
    {
        _attackLineValue = 0;
        UpdateAttackLine();
    }

    private void UpdateAttackLine()
    {
        _attackLine.style.width = _attackLineValue;
    }

    private void UpdateProtectLine()
    {
        _protectLine.style.width = _protectLineValue;
    }
}