using UnityEngine;
using UnityEngine.UIElements;

public class WindowManagement : Singleton<WindowManagement>
{
    [Header("UIDocuments")]

    [SerializeField] private UIDocument _upHudDocument;
    [SerializeField] private UIDocument _rightHudDocument;
    [SerializeField] private UIDocument _generalButtonsDocument;
    [SerializeField] private AssembleSquadHud _assembleSquadHud;
    [SerializeField] private EquipmentHud _equipmentHud;
    [SerializeField] private KraftHud _kraftHud;
    [SerializeField] private UIDocument _clickerHudDocument;
    [SerializeField] private UIDocument _inventoryDocument;
    [SerializeField] private UIDocument _dragItemDocument;
    [SerializeField] private UIDocument _warehouseDocument;

    public UIDocument GetUpHud => _upHudDocument;
    public UIDocument GetRightHud => _rightHudDocument;
    public UIDocument GetGeneralButtons => _generalButtonsDocument;
    public AssembleSquadHud GetAssembleSquadHud => _assembleSquadHud;
    public EquipmentHud GetEquipmentHud => _equipmentHud;
    public KraftHud GetKraftHud => _kraftHud;
    public UIDocument GetClickerHud => _clickerHudDocument;
    public UIDocument GetInventoryHud => _inventoryDocument;
    public UIDocument GetDragItemDocument => _dragItemDocument;
    public UIDocument GetWarehouseDocument => _warehouseDocument;

    [Header("VisualTreeAsset")]

    [SerializeField] private VisualTreeAsset _vtaDevelopSpace;
    [SerializeField] private VisualTreeAsset _vtaListButton;
    [SerializeField] private VisualTreeAsset _vtaClicker;

    public VisualTreeAsset VtaDevelopSpace => _vtaDevelopSpace;
    public VisualTreeAsset VtaListButton => _vtaListButton;
    public VisualTreeAsset VtaClicker => _vtaClicker;

    [Header("VisualTreeAsset Patterns")]

    [SerializeField] private VisualTreeAsset _vtaGeneralButtonPattern;
    public VisualTreeAsset VtaGeneralButtonPattern => _vtaGeneralButtonPattern;

    public void MainHuds(bool active)
    {
        _upHudDocument.enabled = active;
        _rightHudDocument.enabled = active;
    }
}