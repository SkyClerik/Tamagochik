namespace Data.Units
{
    using Behaviours;
    using UnityEngine;

    [System.Serializable]
    public class UnitBase
    {
        [SerializeField] private string _staticName;
        [SerializeField] private string _name;
        [SerializeField] private Sprite _icon;
        [SerializeField] private int _energy;
        [SerializeField] private bool _busy = false;
        [SerializeField] private bool _visible = true;

        public string StaticName { get => _staticName; set => _staticName = value; }
        public string Name { get => _name; set => _name = value; }
        public Sprite Icon { get => _icon; set => _icon = value; }
        public int Energy { get => _energy; set => _energy = value; }
        public bool Busy { get => _busy; set => _busy = value; }
        public bool Visible { get => _visible; set => _visible = value; }
    }


    [System.Serializable]
    public class Humanoid : UnitBase
    {
        [SerializeField] private CustomItem[] _eqiupments;
        [SerializeField] private Inventory _inventory;
        public CustomItem[] Eqiupments { get => _eqiupments; set => _eqiupments = value; }
        public Inventory Inventory { get => _inventory; set => _inventory = value; }

        public ItemBase[] GenerateEmptyEquipment()
        {
            _eqiupments = new CustomItem[]
            {
                new CustomItem(string.Empty, string.Empty, null, 0, 0, true, EquipTypes.Head, StorageTypes.Item,
                    recipes: null),
                new CustomItem(string.Empty, string.Empty, null, 0, 0, true, EquipTypes.LeftArm, StorageTypes.Item,
                    recipes: null),
                new CustomItem(string.Empty, string.Empty, null, 0, 0, true, EquipTypes.RightArm, StorageTypes.Item,
                    recipes: null),
                new CustomItem(string.Empty, string.Empty, null, 0, 0, true, EquipTypes.Torso, StorageTypes.Item,
                    recipes: null),
                new CustomItem(string.Empty, string.Empty, null, 0, 0, true, EquipTypes.Feet, StorageTypes.Item,
                    recipes: null),
            };
            return _eqiupments;
        }

        public void ClearEquipSlot(EquipTypes equipTypes)
        {
            for (int i = 0; i < _eqiupments.Length; i++)
            {
                if (_eqiupments[i].GetEquipType == equipTypes)
                {
                    _eqiupments[i] = new CustomItem(string.Empty, string.Empty, null, 0, 0, true, equipTypes, StorageTypes.Item,
                                        recipes: null);
                }
            }
        }

        public void EquipItem(CustomItem itemBase)
        {
            EquipTypes equipTypes = itemBase.GetEquipType;
            for (int i = 0; i < _eqiupments.Length; i++)
            {
                if (_eqiupments[i].GetEquipType == equipTypes)
                {
                    _eqiupments[i] = itemBase;
                }
            }
        }

        public int GetEquipIndex(EquipTypes equipTypes)
        {
            for (int i = 0; i < _eqiupments.Length; i++)
            {
                if (_eqiupments[i].GetEquipType == equipTypes)
                {
                    return i;
                }
            }
            return -1;
        }
    }


    [System.Serializable]
    public class Animal : UnitBase
    {

    }

    [System.Serializable]
    public class Master : Humanoid
    {
        public Master DeepCopy()
        {
            Master clone = (Master)MemberwiseClone();
            clone.Inventory = base.Inventory.DeepCopy();
            clone.Name = "new master name";
            return clone;
        }
    }
}