using Data.Item;
using UnityEngine;

namespace Data.Units
{
    [System.Serializable]
    [CreateAssetMenu(fileName = "Humanoid", menuName = "Data/Units/Humanoid")]
    public class Humanoid : UnitBase
    {
        [SerializeField]
        private EquipmentItem[] _equipment;
        [SerializeField]
        private ItemContainer _inventory;
        public EquipmentItem[] Equipment { get => _equipment; set => _equipment = value; }
        public ItemContainer Inventory { get => _inventory; set => _inventory = value; }

        private void OnValidate()
        {
            if (_inventory.ItemList.Length < 8)
                _inventory.ItemList = new ItemBase[8];
        }

        public void EquipItem(EquipmentItem equipment)
        {
            EquipTypes equipTypes = equipment.GetEquipType;
            for (int i = 0; i < _equipment.Length; i++)
            {
                if (_equipment[i].GetEquipType == equipTypes)
                {
                    _equipment[i] = equipment;
                }
            }
        }

        public int GetEquipIndex(EquipTypes equipTypes)
        {
            for (int i = 0; i < _equipment.Length; i++)
            {
                if (_equipment[i].GetEquipType == equipTypes)
                {
                    return i;
                }
            }
            return -1;
        }
    }
}