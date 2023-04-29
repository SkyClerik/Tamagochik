using Behaviours;
using UnityEngine;

namespace Behaviours
{
    using System.Collections.Generic;
    using UnityEngine;

    [System.Serializable]
    public class RecipeBase
    {
        [SerializeField] private string _name;
        [SerializeField] private Sprite _icon;
        [SerializeField] private bool _visible = true;
        [SerializeField] private int _coast;
        [SerializeField] List<Demand> _demands = new();

        public string Name { get => _name; set => _name = value; }
        public Sprite Icon { get => _icon; set => _icon = value; }
        public bool Visible { get => _visible; set => _visible = value; }
        public int Coast { get => _coast; set => _coast = value; }
        public List<Demand> Demands { get => _demands; set => _demands = value; }

        public RecipeBase(string name, Sprite icon, bool visible, int coast, List<Demand> demands)
        {
            _name = name;
            _icon = icon;
            _visible = visible;
            _coast = coast;
            _demands = demands;
        }

        public List<DemandResult> GetItemBase()
        {
            var gameDataContainer = GameDataContainer.Instance;
            var itemsData = gameDataContainer.GetItemsData;
            var resourcesData = gameDataContainer.GetResourcesData;

            List<DemandResult> demandResult = new List<DemandResult>();
            foreach (Demand demand in _demands)
            {
                switch (demand.Type)
                {
                    case DataTypes.Item:
                        demandResult.Add(new DemandResult(itemsData.Items[demand.Index], demand.Amount));
                        break;
                    case DataTypes.Resource:
                        demandResult.Add(new DemandResult(resourcesData.Resources[demand.Index], demand.Amount));
                        break;
                }
            }

            return demandResult;
        }
    }
}

[System.Serializable]
public class Demand
{
    [SerializeField] private int _index;
    [SerializeField] private int _amount;
    [SerializeField] private DataTypes _dataType;

    public int Index { get => _index; set => _index = value; }
    public int Amount { get => _amount; set => _amount = value; }
    public DataTypes Type { get => _dataType; set => _dataType = value; }

    public Demand(int index, int amount, DataTypes dataType)
    {
        _index = index;
        _amount = amount;
        _dataType = dataType;
    }
}


[System.Serializable]
public class DemandResult
{
    [SerializeField] private ItemBase _itemBase;
    [SerializeField] private int _amount;

    public ItemBase ItemBase { get => _itemBase; set => _itemBase = value; }
    public int Amount { get => _amount; set => _amount = value; }

    public DemandResult(ItemBase itemBase, int amount)
    {
        _itemBase = itemBase;
        _amount = amount;
    }
}