using UnityEngine;
using UnityEngine.UIElements;

public class UpPanel : MonoBehaviour
{
    private GameDataContainer _gameDataContainer;
    private HudTextData _hudTextData;
    private GameData _gameData;
    private Label _dayValue;
    private Label _monthValue;
    private Label _cashValue;

    private void OnEnable()
    {
        _gameDataContainer = GameDataContainer.Instance;
        _gameDataContainer.OnReady += Init;
    }

    private void Init()
    {
        _gameDataContainer.OnReady -= Init;
        _gameDataContainer.GetGameData.OnDayPassed += UpdateDay;
        _gameDataContainer.GetGameData.OnMonthPassed += UpdateMonth;

        _hudTextData = _gameDataContainer.GetHudTextData;
        _gameData = _gameDataContainer.GetGameData;

        SettingView();
    }

    private void SettingView()
    {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;

        root.Q<Label>("DayTitle").text = _hudTextData.Day.ToString();
        root.Q<Label>("MonthTitle").text = _hudTextData.Month;
        root.Q<Label>("CashTitle").text = _hudTextData.Cash;

        _dayValue = root.Q<Label>("DayValue");
        _monthValue = root.Q<Label>("MonthValue");
        _cashValue = root.Q<Label>("CashValue");

        _dayValue.text = _gameData.Day.ToString();
        _monthValue.text = _gameData.Month.ToString();
        _cashValue.text = _gameData.Cash.ToString();
    }

    private void UpdateDay()
    {
        _dayValue.text = _gameData.Day.ToString();
    }

    private void UpdateMonth()
    {
        _monthValue.text = _gameData.Month.ToString();
    }

    private void UpdateCash()
    {
        _cashValue.text = _gameData.Cash.ToString();
    }
}
