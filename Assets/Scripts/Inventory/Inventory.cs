using Data.Item;
using System.Linq;
using UnityEngine;

[System.Serializable]
public class Inventory
{
    [SerializeField] private ItemBase[] _itemList;

    public ItemBase[] ItemList => _itemList;

    public Inventory(ItemBase[] itemList)
    {
        _itemList = itemList.Take(itemList.Length).ToArray();
    }

    public void AddItem(ItemBase customItem)
    {
        if (_itemList[0] != customItem)
            _itemList[0] = customItem.Copy();

        _itemList[0].Amount += customItem.Amount;
    }

    public void Swap(int index1, int index2)
    {
        Extensions.UtilsExt.Swap(ref _itemList[index1], ref _itemList[index2]);
    }

    public Inventory DeepCopy()
    {
        return new Inventory(_itemList);
    }
}