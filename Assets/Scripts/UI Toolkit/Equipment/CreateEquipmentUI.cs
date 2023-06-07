using UnityEngine.UIElements;

public class CreateEquipmentUI
{
    private UnitBase unit;
    private UIDocument _uiDocument;
    private VisualElement _rootVisualElement;

    public CreateEquipmentUI(UnitBase unit, System.Action callback)
    {
        this.unit = unit;

        WindowManagement windowManagement = WindowManagement.Instance;
        _uiDocument = windowManagement.GetEquipmentDoc;
        _uiDocument.enabled = true;

        _rootVisualElement = _uiDocument.rootVisualElement;
        Label unitName = _rootVisualElement.Q<Label>("UnitNameLable");
        unitName.text = unit.Name;
    }

    public void Hide()
    {
        _uiDocument.enabled = false;
    }
}
