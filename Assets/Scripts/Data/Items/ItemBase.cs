namespace Behaviours
{
    using System.Collections.Generic;
    using UnityEngine;

    [System.Serializable]
    public class ItemBase
    {
        [SerializeField] private string _name;
        [SerializeField] private string _description;
        [SerializeField] private Sprite _icon;
        [SerializeField] private int _amount;
        [SerializeField] private int _id;
        [SerializeField] private StorageTypes _storageType;
        [SerializeField] private List<int> _recipesIndex;

        public string Name { get => _name; set => _name = value; }
        public string Description { get => _description; set => _description = value; }
        public Sprite Icon { get => _icon; set => _icon = value; }
        public int Amount { get => _amount; set => _amount = value; }
        public int Id { get => _id; set => _id = value; }
        public StorageTypes StorageType { get => _storageType; set => _storageType = value; }
        public List<int> RecipesIndex { get => _recipesIndex; set => _recipesIndex = value; }
    }
}