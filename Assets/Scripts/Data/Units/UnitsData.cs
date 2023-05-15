using Data.Units;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "UnitsData", menuName = "Data/UnitsData")]
public class UnitsData : ScriptableObject
{
    [SerializeField] private List<Master> _masters = new();
    [SerializeField] private List<Humanoid> _humanoids = new();
    [SerializeField] private List<Animal> _animals = new();

    public List<Master> MasterList => _masters;
    public List<Humanoid> HumanoidList => _humanoids;
    public List<Animal> AnimalList => _animals;

    public Master GetMasterClone(int index)
    {
        var master = Instantiate(_masters[index]);

        master.Inventory.ItemList = new Data.Item.ItemBase[_masters[index].Inventory.ItemList.Length];
        for (int i = 0; i < master.Inventory.ItemList.Length; i++)
        {
            if (_masters[index].Inventory.ItemList[i] != null)
            {
                master.Inventory.ItemList[i] = Object.Instantiate(_masters[index].Inventory.ItemList[i]);
            }
            else
            {
                master.Inventory.ItemList[i] = null;
            }
        }

        return master;
    }
}