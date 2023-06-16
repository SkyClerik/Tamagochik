using Data.Units;
using Data.World;
using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameData", menuName = "Data/GameData")]
public class GameData : ScriptableObject
{
    [SerializeField]
    private byte _unitsMaxEnergy = 5;
    [SerializeField]
    private Master _master;
    [SerializeField]
    private WarehouseData _playerWarehouse;
    [SerializeField]
    private List<House> _playerHouses;

    private byte _day = 1;
    private byte _month = 1;
    private long _cash = 100;

    public event Action OnDayPassed;
    public event Action OnMonthPassed;

    public byte GetUnitsMaxEnergy => _unitsMaxEnergy;
    public Master Master { get => _master; set => _master = value; }
    public WarehouseData PlayerWarehouse { get => _playerWarehouse; set => _playerWarehouse = value; }
    public List<House> PlayerHouses { get => _playerHouses; set => _playerHouses = value; }

    public byte Day
    {
        get { return _day; }
        set
        {
            _day = value;
            InvokeOnDayPassed();

            if (_day == 31)
            {
                _day = 1;
                Month++;
            }
        }
    }
    public byte Month
    {
        get { return _month; }
        set
        {
            _month = value;
            InvokeOnMonthPassed();

            if (_month == 13)
            {
                _month = 1;
                _day = 1;
            }
        }
    }
    public long Cash
    {
        get { return _cash; }
        set { _cash = value; }
    }

    public void InvokeOnDayPassed()
    {
        OnDayPassed?.Invoke();
    }

    public void InvokeOnMonthPassed()
    {
        OnMonthPassed?.Invoke();
    }
}
