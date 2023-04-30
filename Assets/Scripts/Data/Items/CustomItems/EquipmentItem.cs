using UnityEngine;

namespace Data.Item
{
    public class EquipmentItem : ItemBase
    {
        [SerializeField] private EquipTypes _equipType;

        public EquipTypes GetEquipType => _equipType;

        public new EquipmentItem Copy()
        {
            return Instantiate(this);
        }
    }
}