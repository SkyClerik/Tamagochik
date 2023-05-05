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

        VisualElement root = _uiDocument.rootVisualElement;
        _icon = root.Q<VisualElement>("Icon");

        root.Add(_icon);
    }

    public void AddItem(ItemVisualElement itemVisualElement)
    {
        if (itemVisualElement.Item == null)
            return;

        Sprite icon = itemVisualElement.Item.Icon;
        _icon.style.backgroundImage = new StyleBackground(icon);
        _icon.visible = true;

        _itemVisualElement = itemVisualElement;
        enabled = true;
    }

    public ItemVisualElement GetItem()
    {
        enabled = false;
        _icon.visible = false;
        return _itemVisualElement;
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
