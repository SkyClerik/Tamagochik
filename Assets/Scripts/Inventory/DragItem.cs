using UnityEngine.UIElements;
using UnityEngine;
using UnityEngine.Rendering.VirtualTexturing;

[RequireComponent(typeof(UIDocument))]
public class DragItem : Singleton<DragItem>
{
    private ItemVisualElement _itemVisualElement;
    private VisualElement _icon;
    private UIDocument _uiDocument;
    private VisualElement _root;
    private float _screenHeight;
    private const string _iconName = "Icon";

    public bool IsDragging => _itemVisualElement == null ? false : true;

    private void Awake()
    {
        _screenHeight = Screen.height;
        _uiDocument = GetComponent<UIDocument>();
        _uiDocument.enabled = true;

        _root = _uiDocument.rootVisualElement;
        _icon = _root.Q<VisualElement>(_iconName);
    }

    public void AddItem(ItemVisualElement itemVisualElement)
    {
        _itemVisualElement = itemVisualElement;

        if (itemVisualElement?.Item == null)
            return;

        _screenHeight = Screen.height;
        Sprite icon = itemVisualElement.Item.Icon;
        _icon.style.backgroundImage = new StyleBackground(icon);
        _icon.visible = true;
        enabled = true;
    }

    public void Clear()
    {
        _itemVisualElement = null;
    }

    public ItemVisualElement GetDragItemVisualElement()
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
        Vector2 mousePositionCorrected = new Vector2(mousePosition.x, Screen.height - mousePosition.y);
        mousePositionCorrected = RuntimePanelUtils.ScreenToPanel(_root.panel, mousePositionCorrected);
        _icon.style.left = mousePositionCorrected.x;
        _icon.style.top = mousePositionCorrected.y;
    }
}
