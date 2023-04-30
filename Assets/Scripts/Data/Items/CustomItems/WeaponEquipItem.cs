using UnityEngine;

namespace Data.Item
{
    [CreateAssetMenu(fileName = "WeaponEquipItem", menuName = "Data/Items/WeaponEquipItem")]
    public class WeaponEquipItem : EquipmentItem
    {
        [SerializeField] private int _attack;
        [SerializeField] private int _defence;
        [SerializeField] private int _agility;
        [SerializeField] private int _lucky;
        [SerializeField] private int _magAttack;
        [SerializeField] private int _magDefence;
        [SerializeField] private int _maxHealPpoints;
        [SerializeField] private int _maxMovePoints;
    }
}