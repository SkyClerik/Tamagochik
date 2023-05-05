using UnityEngine.UIElements;
using UnityEngine;

[RequireComponent(typeof(UIDocument))]
public class DragItem : Singleton<DragItem>
{
    private ItemVisualElement _itemVisualElement;
    private VisualElement _icon;
    private UIDocument _uiDocument;
    private float _screenHeight;

    private void Awake()
    {
        _screenHeight = Screen.height;
        _uiDocument = GetComponent<UIDocument>();
        _uiDocument.enabled = true;

        VisualElement root = _uiDocument.rootVisualElement;
        _icon = root.Q<VisualElement>("Icon");

        root.Add(_icon);
    }

    public void AddItem(ItemVisualElement itemVisualElement)
    {
        if (itemVisualElement.Item == null)
            return;

        _screenHeight = Screen.height;
        _itemVisualElement = itemVisualElement;

        Sprite icon = itemVisualElement.Item.Icon;
        _icon.style.backgroundImage = new StyleBackground(icon);
        _icon.visible = true;

        enabled = true;
    }

    public ItemVisualElement GetItem()
    {
        enabled = false;
        _icon.visible = false;
        return _itemVisualElement;
    }

    public void Swap(ItemContainer currentContainer, int index)
    {
        ItemContainer dragContainer = _itemVisualElement.Owner;
        int indexDrag = _itemVisualElement.IndexInInventory;
        Extensions.UtilsExt.Swap(ref currentContainer.ItemList[index], ref dragContainer.ItemList[indexDrag]);
    }

    private void Update()
    {
        SetPosition();
    }

    private void SetPosition()
    {
        Vector2 mousePosition = Input.mousePosition;
        _icon.style.left = mousePosition.x;
        _icon.style.top = _screenHeight - mousePosition.y;
    }
}
