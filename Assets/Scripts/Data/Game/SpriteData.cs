using UnityEngine;

[CreateAssetMenu(fileName = "SpriteData", menuName = "Data/SpriteData")]
public class SpriteData : ScriptableObject
{
    [SerializeField]
    private Sprite _back;
    public Sprite Back => _back;
    [SerializeField]
    private Sprite _close;
    public Sprite Close => _close;
}