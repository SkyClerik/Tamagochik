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
        var master = _masters[index].Clone();

        CloneInventory(_masters[index], master);
        CloneHumanoids(_masters[index], master);

        return master;
    }

    private void CloneInventory(Master toMaster, Master fromMaster)
    {
        fromMaster.Inventory.ItemList = new Data.Item.ItemBase[toMaster.Inventory.ItemList.Length];
        for (int i = 0; i < fromMaster.Inventory.ItemList.Length; i++)
        {
            fromMaster.Inventory.ItemList[i] = toMaster.Inventory.ItemList[i] != null ? toMaster.Inventory.ItemList[i].Clone() : null;
        }
    }

    private void CloneHumanoids(Master toMaster, Master fromMaster)
    {
        fromMaster.Humanoids = new();
        for (int i = 0; i < toMaster.Humanoids.Count; i++)
        {
            fromMaster.Humanoids.Add(toMaster.Humanoids[i].Clone());
        }
    }
}