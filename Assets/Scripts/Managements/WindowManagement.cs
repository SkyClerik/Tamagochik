using UnityEngine;
using UnityEngine.UIElements;

public class WindowManagement : Singleton<WindowManagement>
{
    [Header("UIDocuments")]

    [SerializeField] private UIDocument _upHudDocument;
    [SerializeField] private UIDocument _rightHudDocument;
    [SerializeField] private UIDocument _locationInfoDocument;
    [SerializeField] private UIDocument _generalButtonsDocument;
    [SerializeField] private UIDocument _assembleSquadDocument;
    [SerializeField] private UIDocument _equipmentDocument;
    [SerializeField] private KraftHud _kraftHud;
    [SerializeField] private UIDocument _clickerHudDocument;
    [SerializeField] private UIDocument _inventoryDocument;
    [SerializeField] private UIDocument _warehouseDocument;

    public UIDocument GetRightDoc => _rightHudDocument;
    public UIDocument GetLocationInfoDoc => _locationInfoDocument;
    public UIDocument GetGeneralButtonsDoc => _generalButtonsDocument;
    public UIDocument GetAssembleSquadDoc => _assembleSquadDocument;
    public UIDocument GetEquipmentDoc => _equipmentDocument;
    public KraftHud GetKraftHud => _kraftHud;
    public UIDocument GetClickerDoc => _clickerHudDocument;
    public UIDocument GetInventoryDoc => _inventoryDocument;
    public UIDocument GetWarehouseDoc => _warehouseDocument;

    [Header("VisualTreeAsset")]

    [SerializeField] private VisualTreeAsset _vtaDevelopSpace;
    [SerializeField] private VisualTreeAsset _vtaListButton;

    public VisualTreeAsset VtaDevelopSpace => _vtaDevelopSpace;
    public VisualTreeAsset VtaListButton => _vtaListButton;

    [Header("VisualTreeAsset Patterns")]

    [SerializeField] private VisualTreeAsset _vtaGeneralButtonPattern;
    [SerializeField] private VisualTreeAsset _vtaItemSlotPattern;
    public VisualTreeAsset VtaGeneralButtonPattern => _vtaGeneralButtonPattern;
    public VisualTreeAsset VtaItemSlotPattern => _vtaItemSlotPattern;

    public void MainHuds(bool active)
    {
        _upHudDocument.enabled = active;
        _rightHudDocument.enabled = active;
    }
}