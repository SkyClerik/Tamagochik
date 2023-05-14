using Data.Item;
using UnityEngine.UIElements;

public class ItemVisualElement : VisualElement
{
    private DragItem _dragItem;
    private ItemBase _item;
    private int _indexInInventory;
    private ItemContainer _owner;
    private const string _itemIconClass = "item-icon";

    public ItemBase Item => _item;
    public int IndexInInventory => _indexInInventory;
    public ItemContainer Owner => _owner;


    public ItemVisualElement(ItemBase itemBase, ItemContainer owner, int indexInInventory)
    {
        _dragItem = DragItem.Instance;
        _item = itemBase;
        _owner = owner;
        _indexInInventory = indexInInventory;

        AddToClassList(_itemIconClass);
        SetItem(itemBase);

        RegisterCallback<MouseDownEvent>(OnMouseDownEvent);
        RegisterCallback<MouseUpEvent>(OnMouseUpEvent);
    }

    private void SetItem(ItemBase itemBase)
    {
        _item = itemBase;
        StyleBackground icon = itemBase == null ? null : new StyleBackground(itemBase.Icon);
        style.backgroundImage = icon;
    }

    ~ItemVisualElement()
    {
        UnregisterCallback<MouseDownEvent>(OnMouseDownEvent);
        UnregisterCallback<MouseUpEvent>(OnMouseUpEvent);
    }

    private void OnMouseDownEvent(MouseDownEvent mouseDownEvent)
    {
        if (_dragItem.IsDragging)
            SwapItems();

        _dragItem.AddItem(this);
        style.backgroundImage = null;
    }

    private void OnMouseUpEvent(MouseUpEvent mouseUpEvent)
    {
        if (_dragItem.IsDragging == false)
            return;

        SwapItems();
        _dragItem.Clear();
    }

    private void SwapItems()
    {
        ItemVisualElement oldItemSlot = _dragItem.GetItem();
        ItemBase save = oldItemSlot.Item;
        oldItemSlot.SetItem(_item);
        SetItem(save);
        _dragItem.Swap(_owner, _indexInInventory);
    }
}
