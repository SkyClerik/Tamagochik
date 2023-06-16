using Data.Units;
using Data.World;
using UnityEngine;
using UnityEngine.UIElements;

public class StartClicker
{
    private GameDataContainer _gameDataContainer;
    private Dungeon _dungeon;

    private Humanoid _humanoid;

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
        UIDocument uiDocument = windowManagement.GetClickerDoc;
        uiDocument.enabled = true;

        windowManagement.GetGeneralButtonsDoc.enabled = false;
        windowManagement.GetLocationInfoDoc.enabled = false;

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

        ResetParams();
        new CreateInventoryUI();
    }

    private void ResetParams()
    {
        _humanoid = _gameDataContainer.GetGameData.Master;
        _attackLineValue = 0f;
        _protectLineValue = 0f;
    }

    private void BackButton()
    {
        var windowManagement = WindowManagement.Instance;
        windowManagement.GetInventoryDoc.enabled = false;
        windowManagement.GetGeneralButtonsDoc.enabled = true;

        UIDocument uiDocument = windowManagement.GetClickerDoc;
        uiDocument.enabled = false;

        _dungeon.Outside();
    }

    private void AddRandomItem()
    {
        _attackLineValue = 0;

        var lutList = _dungeon.GetLutData.GetLut;
        var lutID = Random.Range(0, lutList.Count);
        var ammount = Random.Range(lutList[lutID].AmountRange.x, lutList[lutID].AmountRange.y);

        if (_humanoid.Inventory.TryAddItem(lutList[lutID].GetItemBase, ammount) is not true)
            Debug.Log($"Предмет не может быть добавлен. Причина мне не известна!");
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