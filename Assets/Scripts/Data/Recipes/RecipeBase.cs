namespace Data.Item
{
    using System.Collections.Generic;
    using UnityEngine;

    [System.Serializable]
    public class RecipeBase
    {
        [SerializeField] private string _name;
        [SerializeField] private bool _visible = true;
        [SerializeField] private int _coast;
        [SerializeField] private ItemInQuantity _resultItem;
        [SerializeField] List<ItemInQuantity> _itemInQuantity = new();

        public string Name { get => _name; set => _name = value; }
        public ItemInQuantity Result => _resultItem;
        public bool Visible { get => _visible; set => _visible = value; }
        public int Coast => _coast;
        public List<ItemInQuantity> GetItemInQuantity => _itemInQuantity;

    }

    [System.Serializable]
    public class ItemInQuantity
    {
        [SerializeField] private ItemBase _itemBase;
        [SerializeField] private int _amount;

        public ItemBase ItemBase { get => _itemBase; set => _itemBase = value; }
        public int Amount { get => _amount; set => _amount = value; }

        public ItemInQuantity(ItemBase itemBase, int amount)
        {
            _itemBase = itemBase;
            _amount = amount;
        }
    }
}