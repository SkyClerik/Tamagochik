namespace Data.Units
{
    using Data.Item;
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
        [SerializeField] private EquipmentItem[] _eqiupments;
        [SerializeField] private Inventory _inventory;
        public EquipmentItem[] Eqiupments { get => _eqiupments; set => _eqiupments = value; }
        public Inventory Inventory { get => _inventory; set => _inventory = value; }

        public void EquipItem(EquipmentItem equipment)
        {
            EquipTypes equipTypes = equipment.GetEquipType;
            for (int i = 0; i < _eqiupments.Length; i++)
            {
                if (_eqiupments[i].GetEquipType == equipTypes)
                {
                    _eqiupments[i] = equipment;
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