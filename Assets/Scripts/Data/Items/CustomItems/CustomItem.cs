namespace Behaviours
{
    using System.Collections.Generic;
    using UnityEngine;

    [System.Serializable]
    public class CustomItem : ItemBase
    {
        [SerializeField] private int _coast;
        [SerializeField] private bool _important;
        [SerializeField] private EquipTypes _equipType;

        public int Coast { get => _coast; set => _coast = value; }
        public bool GetImportant => _important;
        public EquipTypes GetEquipType => _equipType;

        public CustomItem(string name, string description, Sprite icon, int amount, int coast, bool important, EquipTypes equipType, StorageTypes storageType, List<int> recipes = null)
        {
            Name = name;
            Description = description;
            Icon = icon;
            Amount = amount;
            Id = -1;
            _coast = coast;
            _important = important;
            _equipType = equipType;
            StorageType = storageType;
            RecipesIndex = recipes;
        }

        public CustomItem DeepCopy()
        {
            CustomItem clone = (CustomItem)MemberwiseClone();
            clone.Amount = 1;
            return clone;
        }
    }
}

////[CreateAssetMenu(fileName = "Item", menuName = "Data/Items/Item")]
//public class Item : ItemBase
//{
//    // тип предмета
//    // область действия
//    // доступность
//    // потребляется?

//    // отдельным полем есть урон который считается по формуле и имеет тип урона
//    // параметры при вызове: скорость, успех, количество повторов, прирост TP?
//}

////[CreateAssetMenu(fileName = "Weapon", menuName = "Data/Items/Weapon")]
//public class Weapon : ItemBase
//{
//    // тип оружия
//    // тип экипировки

//    [SerializeField] private int _attack;
//    [SerializeField] private int _defence;
//    [SerializeField] private int _agility;
//    [SerializeField] private int _lucky;
//    [SerializeField] private int _magAttack;
//    [SerializeField] private int _magDefence;
//    [SerializeField] private int _maxHealPpoints;
//    [SerializeField] private int _maxMovePoints;

//}

////[CreateAssetMenu(fileName = "Armor", menuName = "Data/Items/Armor")]
//public class Armor : ItemBase
//{
//    // тип брони
//    // тип экипировки
//}

////[CreateAssetMenu(fileName = "Potion", menuName = "Data/Items/Potion")]
//public class Potion : ItemBase
//{
//}