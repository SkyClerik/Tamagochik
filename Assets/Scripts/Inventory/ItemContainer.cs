using Data.Item;
using System.Linq;
using UnityEngine;

[System.Serializable]
public class ItemContainer
{
    [SerializeField] 
    private ItemBase[] _itemList;

    public ItemBase[] ItemList => _itemList;

    public ItemContainer(ItemBase[] itemList)
    {
        _itemList = itemList.Take(itemList.Length).ToArray();
    }

    public void AddItem(ItemBase customItem)
    {
        if (_itemList[0] != customItem)
            _itemList[0] = customItem.Copy();

        _itemList[0].Amount += customItem.Amount;
    }

    public ItemContainer DeepCopy()
    {
        return new ItemContainer(_itemList);
    }
}