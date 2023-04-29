namespace Data.Items
{
    using UnityEngine;

    [CreateAssetMenu(fileName = "ItemTextsData", menuName = "Data/Items/TextsData")]
    public class ItemTextsData : ScriptableObject
    {
        [SerializeField] private string _item_1_name = "Меч скваера";
        [SerializeField] private string _item_1_Description = "_item_1_Description";
        [SerializeField] private string _item_2_name = "Трость";
        [SerializeField] private string _item_2_Description = "_item_2_Description";
        [SerializeField] private string _item_3_name = "Малое зелье лечения";
        [SerializeField] private string _item_3_Description = "_item_3_Description";
        [SerializeField] private string _item_4_name = "Эпический нагрудник";
        [SerializeField] private string _item_4_Description = "_item_4_Description";

        public string Item_1_name => _item_1_name;
        public string Item_1_Description => _item_1_Description;
        public string Item_2_name => _item_2_name;
        public string Item_2_Description => _item_2_Description;
        public string Item_3_name => _item_3_name;
        public string Item_3_Description => _item_3_Description;
        public string Item_4_name => _item_4_name;
        public string Item_4_Description => _item_4_Description;
    }
}
