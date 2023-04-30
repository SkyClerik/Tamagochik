using Data.Item;
using Data.Units;
using Hud.Buttons;
using UnityEngine;
using UnityEngine.UIElements;

public class StartClicker
{
    GameDataContainer _gameDataContainer;
    private Rect _leftArea;
    private Rect _windowArea;

    private Humanoid _humanoid;
    private ItemBase[] _lutList;

    private float _lineMaxValue = 242; //TODO погуглить как получить размер

    private float _stepLineA = 6;
    private float _attackLineValue;

    private float _stepLineB = 20;
    private float _protectLineValue;

    private VisualElement _attackLine;
    private VisualElement _protectLine;

    public StartClicker()
    {
        _gameDataContainer = GameDataContainer.Instance;

        WindowManagement windowManagement = WindowManagement.Instance;
        UIDocument uiDocument = windowManagement.GetClickerHud;
        uiDocument.enabled = true;

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
            _lutList[i] = _gameDataContainer.GetItemsData.Items[i].Copy();
        }
    }

    private void BackButton()
    {
        var windowManagement = WindowManagement.Instance;
        windowManagement.MainHuds(true);
        windowManagement.GetInventoryHud.enabled = false;

        UIDocument uiDocument = windowManagement.GetClickerHud;
        uiDocument.enabled = false;

        new StartDevelopSpace();
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