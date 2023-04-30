namespace Data.Item
{
    using System.Collections.Generic;
    using UnityEngine;

    [CreateAssetMenu(fileName = "ItemsData", menuName = "Data/Items/ItemsData")]
    public class ItemsData : ScriptableObject
    {
        [SerializeField]
        private List<ItemBase> _items;
        public List<ItemBase> Items { get => _items; set => _items = value; }
    }
}