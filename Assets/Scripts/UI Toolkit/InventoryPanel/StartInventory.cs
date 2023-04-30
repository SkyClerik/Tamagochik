using Data.Item;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;

public class StartInventory
{
    private Inventory _inventory;
    private VisualElement _rootVisualElement;
    private List<VisualElement> _slots = new List<VisualElement>();

    public VisualElement GetRootVisualElement => _rootVisualElement;

    public StartInventory()
    {
        GameDataContainer gameDataContainer = GameDataContainer.Instance;
        _inventory = gameDataContainer.GetGameData.Master.Inventory;

        WindowManagement windowManagement = WindowManagement.Instance;
        UIDocument uiDocument = windowManagement.GetInventoryHud;
        uiDocument.enabled = true;

        _rootVisualElement = uiDocument.rootVisualElement;

        ScrollView scrollView = _rootVisualElement.Q<ScrollView>("InventoryScrollView");

        List<VisualElement> lines = scrollView.Children().ToList();

        foreach (VisualElement line in lines)
        {
            List<VisualElement> slots = line.Children().ToList();

            for (int i = 0; i < slots.Count; i++)
            {
                _slots.Add(slots[i]);
            }
        }

        for (int i = 0; i < _inventory.ItemList.Length; i++)
        {
            ItemBase item = _inventory.ItemList[i];

            if (item != null)
                new ItemVisualElement(item, startInventory: this, parentElement: _slots[i]);
        }
    }

    public bool IsSlotEmpty(Vector2 mousePosition, out VisualElement emptySlot)
    {
        for (int i = 0; i < _slots.Count; i++)
        {
            if (_slots[i].worldBound.Contains(mousePosition))
            {
                if (_slots[i].childCount == 0)
                {
                    emptySlot = _slots[i];
                    return true;
                }
            }
        }
        emptySlot = null;
        return false;
    }
}

public class ItemVisualElement : VisualElement
{
    private ItemBase _item;
    private bool _isDragging;
    private VisualElement _parentElement;
    private VisualElement _rootVisualElement;
    private StartInventory _startInventory;

    public ItemVisualElement(ItemBase itemBase, StartInventory startInventory, VisualElement parentElement)
    {
        _item = itemBase;
        _startInventory = startInventory;
        _rootVisualElement = startInventory.GetRootVisualElement;
        _parentElement = parentElement;
        _parentElement.Add(this);

        style.backgroundImage = new StyleBackground(itemBase.Icon);
        AddToClassList("item-icon");

        RegisterCallback<MouseDownEvent>(OnMouseDownEvent);
        RegisterCallback<MouseMoveEvent>(OnMouseMoveEvent);
        RegisterCallback<MouseUpEvent>(OnMouseUpEvent);
    }
    ~ItemVisualElement()
    {
        UnregisterCallback<MouseMoveEvent>(OnMouseMoveEvent);
        UnregisterCallback<MouseDownEvent>(OnMouseDownEvent);
        UnregisterCallback<MouseUpEvent>(OnMouseUpEvent);
    }

    private void OnMouseDownEvent(MouseDownEvent mouseDownEvent)
    {
        StartDrag(mouseDownEvent);
    }

    private void OnMouseMoveEvent(MouseMoveEvent mouseEvent)
    {
        if (!_isDragging)
            return;

        SetPosition(GetMousePosition(mouseEvent.mousePosition));
    }

    private void OnMouseUpEvent(MouseUpEvent mouseUpEvent)
    {
        if (_startInventory.IsSlotEmpty(mouseUpEvent.mousePosition, out VisualElement emptySlot))
        {
            emptySlot.Add(this);
            _parentElement = emptySlot;
        }
        else
        {
            _parentElement.Add(this);
        }

        _isDragging = false;
        SetPosition(Vector2.zero);
    }

    public void StartDrag(IMouseEvent mouseEvent)
    {
        _isDragging = true;
        _rootVisualElement.Add(this);
        SetPosition(GetMousePosition(mouseEvent.mousePosition));
    }

    public void SetPosition(Vector2 pos)
    {
        style.left = pos.x;
        style.top = pos.y;
    }

    public Vector2 GetMousePosition(Vector2 mousePosition) => new Vector2(mousePosition.x - (layout.width / 2) - parent.worldBound.position.x, mousePosition.y - (layout.height / 2) - parent.worldBound.position.y);

}