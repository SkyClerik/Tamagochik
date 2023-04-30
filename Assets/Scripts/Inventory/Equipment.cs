using UnityEngine;
using Data.Item;

[System.Serializable]
public class Equipment
{
    [SerializeField]
    private HeadEquipItem _head;
    [SerializeField]
    private WeaponEquipItem _weapon;
    [SerializeField]
    private RingEquipItem _ring;

    public HeadEquipItem Head => _head;
    public WeaponEquipItem Weapon => _weapon;
    public RingEquipItem Ring => _ring;

    public void SetHead(HeadEquipItem headEquipItem)
    {
        _head = headEquipItem;
    }

    public void SetWeapon(WeaponEquipItem weaponEquipItem)
    {
        _weapon = weaponEquipItem;
    }

    public void SetHead(RingEquipItem ringEquipItem)
    {
        _ring = ringEquipItem;
    }
}