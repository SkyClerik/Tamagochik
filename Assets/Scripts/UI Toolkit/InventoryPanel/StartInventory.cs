using Data.Item;
using Data.Units;
using System.Collections.Generic;
using System.Linq;
using UnityEditorInternal.Profiling.Memory.Experimental;
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
            _slots[i].Add(new ItemVisualElement(item, _inventory, i));
        }
    }
}

public class ItemVisualElement : VisualElement
{
    private ItemBase _item;
    private StyleBackground _icon;
    private int _indexInInventory;
    private Inventory _owner;

    public ItemBase Item => _item;
    public int IndexInInventory => _indexInInventory;

    public ItemVisualElement(ItemBase itemBase, Inventory owner, int indexInInventory)
    {
        _item = itemBase;
        _owner = owner;
        _indexInInventory = indexInInventory;

        AddToClassList("item-icon");
        SetItem(itemBase);

        RegisterCallback<MouseDownEvent>(OnMouseDownEvent);
        RegisterCallback<MouseUpEvent>(OnMouseUpEvent);
    }

    public void SetItem(ItemBase itemBase)
    {
        _item = itemBase;
        _icon = itemBase == null ? null : new StyleBackground(itemBase.Icon);
        style.backgroundImage = _icon;
    }

    ~ItemVisualElement()
    {
        UnregisterCallback<MouseDownEvent>(OnMouseDownEvent);
        UnregisterCallback<MouseUpEvent>(OnMouseUpEvent);
    }

    private void OnMouseDownEvent(MouseDownEvent mouseDownEvent)
    {
        DragItem.Instance.AddItem(this);
        style.backgroundImage = null;
    }

    private void OnMouseUpEvent(MouseUpEvent mouseUpEvent)
    {
        DragItem dragItem = DragItem.Instance;
        ItemVisualElement oldItemSlot = dragItem.GetItem();
        if (IsSlotEmpty())
        {
            SetItem(oldItemSlot.Item);
            oldItemSlot.SetItem(null);
            _owner.Swap(_indexInInventory, oldItemSlot.IndexInInventory);

        }
        else
        {
            oldItemSlot.SetItem(oldItemSlot.Item);
        }
    }

    private bool IsSlotEmpty()
    {
        if (_item == null)
            return true;

        return false;
    }
}