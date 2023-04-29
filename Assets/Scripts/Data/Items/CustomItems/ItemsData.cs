namespace Data.Items
{
    using Behaviours;
    using System.Collections.Generic;
    using UnityEngine;

    [CreateAssetMenu(fileName = "ItemsData", menuName = "Data/Items/ItemsData")]
    public class ItemsData : ScriptableObject
    {
        [SerializeField]
        private List<CustomItem> _items;
        public List<CustomItem> Items { get => _items; set => _items = value; }

        public void Calculate(ItemTextsData itemTextsData, ItemIconsData itemIconsData)
        {
            Debug.Log($"Calculate");
            _items = new List<CustomItem>()
            {
                new CustomItem(itemTextsData.Item_1_name, itemTextsData.Item_1_Description, itemIconsData.Item_1, amount: 1, coast: 0, important: false, EquipTypes.Head, StorageTypes.Item,
                recipes: new List<int> {0}),
                new CustomItem(itemTextsData.Item_2_name, itemTextsData.Item_2_Description, itemIconsData.Item_2, amount : 1, coast: 0, important: false, EquipTypes.LeftArm, StorageTypes.Item,
                recipes: new List<int> {1,2}),
                new CustomItem(itemTextsData.Item_3_name, itemTextsData.Item_3_Description, itemIconsData.Item_3, amount : 1, coast: 0, important: false, EquipTypes.Feet, StorageTypes.Item,
                recipes: new List<int> {2,3}),
                new CustomItem(itemTextsData.Item_4_name, itemTextsData.Item_4_Description, itemIconsData.Item_4, amount: 1, coast: 0, important: false, EquipTypes.Torso, StorageTypes.Resource,
                recipes: null),
            };

            // Auto generate index
            for (int i = 0; i < _items.Count; i++)
            {
                _items[i].Id = i;
            }
        }

        public ItemBase GetItemBase(int id)
        {
            for (int i = 0; i < _items.Count; i++)
            {
                if (Items[i].Id == id)
                    return Items[i];
            }
            return null;
        }
    }
}