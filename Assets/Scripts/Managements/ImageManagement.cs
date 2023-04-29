using System;
using UnityEngine;
using UnityEngine.UI;

public class ImageManagement : Singleton<ImageManagement>
{
    [SerializeField] private Image _fakeBody;
    public Image FakeBody { get { return _fakeBody; } set { _fakeBody = value; } }
    [SerializeField] private Image _assistBody;
    public Image AssistBody { get { return _assistBody; } set { _assistBody = value; } }
    [SerializeField] private Image _slaveBody;
    public Image SlaveBody { get { return _slaveBody; } set { _slaveBody = value; } }
    [SerializeField] private Image _mainBackground;
    public Image MainBackground { get { return _mainBackground; } set { _mainBackground = value; } }
    [SerializeField] private Image _fakeBackground;
    public Image FakeBackground { get { return _fakeBackground; } set { _fakeBackground = value; } }

    private bool IsImageNull(Image image)
    {
        if (image == null)
        {
            Debug.Log($"ты забыл указать изображение", gameObject);
            return true;
        }

        return false;
    }

    public void ImageSetActive(Image image, bool active)
    {
        if (IsImageNull(image))
            return;

        image.enabled = active;
    }

    public void TransferTo(Image image, TextAnchor anchor, HorizontalDirection direction, float width)
    {
        if (IsImageNull(image))
            return;

        image.SetNativeSize();
        image.rectTransform.localScale = new Vector2(Convert.ToSingle(direction), 1);
        var ratio = image.rectTransform.sizeDelta.x / image.rectTransform.sizeDelta.y;
        var newH = width / ratio;
        image.rectTransform.sizeDelta = new Vector2(width, newH);

        UpdateTransfer(image, anchor);
    }

    private static void UpdateTransfer(Image image, TextAnchor anchor)
    {
        float w = 0;
        float h = 0;
        switch (anchor)
        {
            case TextAnchor.UpperLeft:
                image.rectTransform.anchorMin = new Vector2(0, 1);
                image.rectTransform.anchorMax = new Vector2(0, 1);
                w = image.rectTransform.sizeDelta.x / 2;
                h = image.rectTransform.sizeDelta.y / 2;
                image.rectTransform.anchoredPosition = new Vector2(w, -h);
                break;

            case TextAnchor.UpperCenter:
                image.rectTransform.anchorMin = new Vector2(0.5f, 1);
                image.rectTransform.anchorMax = new Vector2(0.5f, 1);
                h = image.rectTransform.sizeDelta.y / 2;
                image.rectTransform.anchoredPosition = new Vector2(w, -h);
                break;

            case TextAnchor.UpperRight:
                image.rectTransform.anchorMin = new Vector2(1, 1);
                image.rectTransform.anchorMax = new Vector2(1, 1);
                w = image.rectTransform.sizeDelta.x / 2;
                h = image.rectTransform.sizeDelta.y / 2;
                image.rectTransform.anchoredPosition = new Vector2(-w, -h);
                break;

            case TextAnchor.MiddleLeft:
                image.rectTransform.anchorMin = new Vector2(0, 0.5f);
                image.rectTransform.anchorMax = new Vector2(0, 0.5f);
                w = image.rectTransform.sizeDelta.x / 2;
                image.rectTransform.anchoredPosition = new Vector2(w, -h);
                break;

            case TextAnchor.MiddleCenter:
                image.rectTransform.anchorMin = new Vector2(0.5f, 0.5f);
                image.rectTransform.anchorMax = new Vector2(0.5f, 0.5f);
                image.rectTransform.anchoredPosition = new Vector2(w, -h);
                break;

            case TextAnchor.MiddleRight:
                image.rectTransform.anchorMin = new Vector2(1, 0.5f);
                image.rectTransform.anchorMax = new Vector2(1, 0.5f);
                w = image.rectTransform.sizeDelta.x / 2;
                image.rectTransform.anchoredPosition = new Vector2(-w, -h);
                break;

            case TextAnchor.LowerLeft:
                image.rectTransform.anchorMin = new Vector2(0, 0);
                image.rectTransform.anchorMax = new Vector2(0, 0);
                w = image.rectTransform.sizeDelta.x / 2;
                h = image.rectTransform.sizeDelta.y / 2;
                image.rectTransform.anchoredPosition = new Vector2(w, h);
                break;

            case TextAnchor.LowerCenter:
                image.rectTransform.anchorMin = new Vector2(0.5f, 0);
                image.rectTransform.anchorMax = new Vector2(0.5f, 0);
                h = image.rectTransform.sizeDelta.y / 2;
                image.rectTransform.anchoredPosition = new Vector2(-w, h);
                break;

            case TextAnchor.LowerRight:
                image.rectTransform.anchorMin = new Vector2(1, 0);
                image.rectTransform.anchorMax = new Vector2(1, 0);
                w = image.rectTransform.sizeDelta.x / 2;
                h = image.rectTransform.sizeDelta.y / 2;
                image.rectTransform.anchoredPosition = new Vector2(-w, h);
                break;
        }
    }
}