using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class DebScript : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;

    [SerializeField]
    private Sprite[] _sprites;

    [SerializeField]
    [Range(0.1f, 3f)]
    private float _time = 1f;
    [SerializeField]
    [Range(0.1f, 3f)]
    private float _repeatRate = 1f;

    private int _currentValue = 0;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        InvokeRepeating(nameof(Change), _time, _repeatRate);
        gameObject.SetActive(false);
    }

    private void Change()
    {
        _currentValue = _currentValue == 0 ? 1 : 0;
        _spriteRenderer.sprite = _sprites[_currentValue];
    }
}
