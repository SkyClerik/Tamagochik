using Data.Item;
using UnityEngine.UIElements;

public class ItemVisualElement : VisualElement
{
    private ItemBase _item;
    private StyleBackground _icon;
    private int _indexInInventory;
    private ItemContainer _owner;

    public ItemBase Item => _item;
    public int IndexInInventory => _indexInInventory;
    public ItemContainer Owner => _owner;

    public ItemVisualElement(ItemBase itemBase, ItemContainer owner, int indexInInventory)
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
            dragItem.Swap(_owner, _indexInInventory);
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
