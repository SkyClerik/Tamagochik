using UnityEngine;

[CreateAssetMenu(fileName = "ImageData", menuName = "Data/ImageIconData")]
public class HudIconData : ScriptableObject
{
    [SerializeField]
    private Sprite _back;
    public Sprite Back => _back;
    [SerializeField]
    private Sprite _close;
    public Sprite Close => _close;
}