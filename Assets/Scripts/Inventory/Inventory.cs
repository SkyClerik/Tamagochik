using Behaviours;
using System.Linq;
using UnityEngine;

[System.Serializable]
public class Inventory
{
    [SerializeField] private CustomItem[] _itemList;

    public CustomItem[] ItemList => _itemList;

    public Inventory(CustomItem[] itemList)
    {
        _itemList = itemList.Take(itemList.Length).ToArray();
    }

    public void AddItem(CustomItem customItem)
    {
        if (_itemList[0] != customItem)
            _itemList[0] = customItem.DeepCopy();

        _itemList[0].Amount += customItem.Amount;
    }

    public CustomItem GetItemAt(int index)
    {
        return string.IsNullOrEmpty(_itemList[index].Name) ? null : _itemList[index];
    }

    public Inventory DeepCopy()
    {
        return new Inventory(_itemList);
    }
}