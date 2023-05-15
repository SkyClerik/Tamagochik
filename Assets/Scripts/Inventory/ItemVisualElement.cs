using Data.Item;
using UnityEngine;
using UnityEngine.UIElements;

public class ItemVisualElement : VisualElement
{
    private DragItem _dragItem;
    private ItemBase _item;
    private int _indexInInventory;
    private ItemContainer _owner;
    private Label _quantity;
    private VisualElement _itemIconBase;

    public ItemBase Item => _item;
    public int IndexInInventory => _indexInInventory;
    public ItemContainer Owner => _owner;


    public ItemVisualElement(ItemBase itemBase, ItemContainer owner, int indexInInventory)
    {
        _dragItem = DragItem.Instance;
        _item = itemBase;
        _owner = owner;
        _indexInInventory = indexInInventory;

        AddToClassList("item-icon");
        AddPattern();
        SetItem(itemBase);

        RegisterCallback<MouseDownEvent>(OnMouseDownEvent);
        RegisterCallback<MouseUpEvent>(OnMouseUpEvent);
    }

    private void SetItem(ItemBase itemBase)
    {
        _item = itemBase;
        if (itemBase != null)
        {
            Visible();
            UpdateQuantity();
        }
    }

    private void AddPattern()
    {
        WindowManagement windowManagement = WindowManagement.Instance;
        VisualTreeAsset itemSlotVisualTree = windowManagement.VtaItemSlotPattern;
        TemplateContainer template = itemSlotVisualTree.Instantiate();
        _itemIconBase = template.Q<VisualElement>("ItemIconBase");
        _itemIconBase.visible = false;
        _quantity = template.Q<Label>("Quantity");
        Add(template);
    }

    private void UpdateQuantity()
    {
        var amount = _item.Amount > 0 ? $"{_item.Amount}" : string.Empty;
        _quantity.text = _item != null ? amount : string.Empty;
        _itemIconBase.visible = !string.IsNullOrEmpty(amount);
    }

    public void SetBorders(VisualElement e, Color color, float borderWidth)
    {
        e.style.borderTopWidth = e.style.borderLeftWidth = e.style.borderRightWidth = e.style.borderBottomWidth = borderWidth;
        e.style.borderTopColor = e.style.borderLeftColor = e.style.borderRightColor = e.style.borderBottomColor = color;
    }

    private void Visible()
    {
        style.backgroundImage = new StyleBackground(_item.Icon);
        SetBorders(this, Color.blue, 2);
        UpdateQuantity();
    }

    private void Hide()
    {
        style.backgroundImage = null;
        SetBorders(this, Color.blue, 0);
        _itemIconBase.visible = false;
    }

    ~ItemVisualElement()
    {
        UnregisterCallback<MouseDownEvent>(OnMouseDownEvent);
        UnregisterCallback<MouseUpEvent>(OnMouseUpEvent);
    }

    private void OnMouseDownEvent(MouseDownEvent mouseDownEvent)
    {
        if (_dragItem.IsDragging)
        {
            var DragVisualElement = _dragItem.GetDragItemVisualElement();
            ItemBase dragedItem = _dragItem.GetDragItemVisualElement().Item;
            if (DragVisualElement != this)
            {
                if (IsStaked(dragedItem))
                {
                    StackItems(dragedItem);
                    _dragItem.Clear();
                    return;
                }
                else
                {
                    SwapItems();
                    _dragItem.Clear();
                    return;
                }
            }
            else
            {
                _dragItem.Clear();
                Visible();
                return;
            }
        }

        if (_item != null)
        {
            _dragItem.AddItem(this);
            Hide();
        }
    }

    private void OnMouseUpEvent(MouseUpEvent mouseUpEvent)
    {
        if (_dragItem.IsDragging == false)
            return;

        if (_item == null)
        {
            SwapItems();
        }
        else
        {
            var DragVisualElement = _dragItem.GetDragItemVisualElement();
            ItemBase dragedItem = _dragItem.GetDragItemVisualElement().Item;
            if (DragVisualElement != this)
            {
                if (IsStaked(dragedItem))
                {
                    StackItems(dragedItem);
                }
                else
                {
                    SwapItems();
                }
            }
            else
            {
                _dragItem.Clear();
                Visible();
                return;
            }
        }

        _dragItem.Clear();
    }

    private void SwapItems()
    {
        ItemVisualElement oldItemSlot = _dragItem.GetDragItemVisualElement();
        ItemBase save = oldItemSlot.Item;
        oldItemSlot.SetItem(_item);
        SetItem(save);
        _dragItem.Swap(_owner, _indexInInventory);
    }

    private void StackItems(ItemBase dragedItem)
    {
        _item.Amount += dragedItem.Amount;
        Object.Destroy(dragedItem);
        UpdateQuantity();
    }

    private bool IsStaked(ItemBase dragedItem)
    {
        if (_item != null && dragedItem != null)
        {
            if (dragedItem?.name == _item?.name)
            {
                if (_item.MaxAmount > 1)
                {
                    return true;
                }
            }
        }
        return false;
    }
}
