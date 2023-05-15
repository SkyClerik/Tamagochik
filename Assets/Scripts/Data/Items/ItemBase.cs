namespace Data.Item
{
    using System.Collections.Generic;
    using UnityEngine;

    [System.Serializable]
    [CreateAssetMenu(fileName = "Item", menuName = "Data/Items/Item")]
    public class ItemBase : ScriptableObject
    {
        [SerializeField] private string _name;
        [SerializeField] private string _description;
        [SerializeField] private Sprite _icon;
        [SerializeField] private int _amount;
        [SerializeField] private int _maxAmount;
        [SerializeField] private int _id;
        [SerializeField] private StorageTypes _storageType;
        [SerializeField] private List<int> _recipesIndex;
        [SerializeField] private int _coast;
        [SerializeField] private bool _important;

        public string Name { get => _name; set => _name = value; }
        public string Description { get => _description; set => _description = value; }
        public Sprite Icon { get => _icon; set => _icon = value; }
        public int Amount { get => _amount; set => _amount = value; }
        public int MaxAmount => _maxAmount;
        public int Id { get => _id; set => _id = value; }
        public StorageTypes StorageType { get => _storageType; set => _storageType = value; }
        public List<int> RecipesIndex { get => _recipesIndex; set => _recipesIndex = value; }
        public int Coast { get => _coast; set => _coast = value; }
        public bool GetImportant => _important;
    }
}