namespace Data.Items
{
    using UnityEngine;

    [CreateAssetMenu(fileName = "ItemIconsData", menuName = "Data/Items/IconsData")]
    public class ItemIconsData : ScriptableObject
    {
        [SerializeField] private Sprite _item_1;
        [SerializeField] private Sprite _item_2;
        [SerializeField] private Sprite _item_3;
        [SerializeField] private Sprite _item_4;
        public Sprite Item_1 => _item_1;
        public Sprite Item_2 => _item_2;
        public Sprite Item_3 => _item_3;
        public Sprite Item_4 => _item_4;
    }
}