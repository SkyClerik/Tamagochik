using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

public class MoveLutItem : MonoBehaviour
{
    private UIDocument _document;
    private VisualElement _root;
    private string _inventoryIconName = "InventoryIcon";
    private string _moveIconName = "MoveIcon";
    private VisualElement _inventoryIcon;
    private Vector2 _endPoint;
    private Button _moveIconButton;

    [SerializeField]
    [Range(1, 100)]
    private float _moveSpeed;
    private float _scaleValue;
    private float _scaleTime;

    void Start()
    {
        WindowManagement windowManagement = WindowManagement.Instance;
        _document = GetComponent<UIDocument>();
        _root = _document.rootVisualElement;
        _inventoryIcon = _root.Q<VisualElement>(_inventoryIconName);
        _moveIconButton = _root.Q<Button>(_moveIconName);
        IconSetEnabled(false);
        StartCoroutine(nameof(DebugUpdate));
    }

    private IEnumerator DebugUpdate()
    {
        while (true)
        {
            yield return new WaitForSeconds(10f);

            VisualElement parent = _moveIconButton.parent;
            Rect parentRect = parent.contentRect;
            var randomX = Random.Range(parentRect.xMin, parentRect.xMax);
            var randomY = Random.Range(parentRect.yMin, parentRect.yMax);
            _moveIconButton.transform.position = new Vector2(randomX, randomY);
            _moveIconButton.clicked += CreateButton_clicked;
            _moveIconButton.transform.scale = Vector3.one;
            _scaleValue = 0;
            _scaleTime = _moveSpeed * Time.deltaTime;
            IconSetEnabled(true);
        }
    }

    private void CreateButton_clicked()
    {
        _endPoint = new Vector2(_inventoryIcon.layout.xMin, _inventoryIcon.layout.yMin);
        _moveIconButton.clicked -= CreateButton_clicked;
        StartCoroutine(nameof(Moved));
    }

    private IEnumerator Moved()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.05f);

            _moveIconButton.transform.scale = Vector3.Lerp(Vector3.one, Vector3.zero, _scaleValue += _scaleTime);

            _moveIconButton.transform.position = Vector2.MoveTowards(_moveIconButton.transform.position, _endPoint, _moveSpeed);
            if (_moveIconButton.transform.position.magnitude == _endPoint.magnitude)
            {
                StopCoroutine(nameof(Moved));
                IconSetEnabled(false);
            }
        }
    }

    private void IconSetEnabled(bool value)
    {
        _moveIconButton.SetEnabled(value);
        _moveIconButton.visible = value;
    }
}
