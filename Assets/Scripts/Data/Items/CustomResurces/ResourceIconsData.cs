namespace Data.Resources
{
    using UnityEngine;

    [CreateAssetMenu(fileName = "ResourceIconsData", menuName = "Data/Resources/IconsData")]
    public class ResourceIconsData : ScriptableObject
    {
        [SerializeField] private Sprite _iron;
        [SerializeField] private Sprite _wood;
        [SerializeField] private Sprite _gold;
        [SerializeField] private Sprite _stone;
        public Sprite Iron => _iron;
        public Sprite Wood => _wood;
        public Sprite Gold => _gold;
        public Sprite Stone => _stone;
    }
}