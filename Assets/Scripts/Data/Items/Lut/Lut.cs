using UnityEngine;

namespace Data.Item
{
    [System.Serializable]
    public class Lut
    {
        [SerializeField]
        ItemBase _itemBase;
        [SerializeField]
        private Vector2Int _amountRange = new Vector2Int(1, 1);
        [SerializeField]
        [Range(0.0001f, 100)]
        private float _dropChance = 0.0001f;

        public ItemBase GetItemBase => _itemBase;
        public Vector2Int AmountRange => _amountRange;
        public float DropChance => _dropChance;
    }
}