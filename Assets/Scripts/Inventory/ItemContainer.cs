using Data.Item;
using UnityEngine;

[System.Serializable]
public class ItemContainer
{
    [SerializeField]
    private ItemBase[] _itemList;
    public ItemBase[] ItemList { get => _itemList; set => _itemList = value; }

    public void AddItem(ItemBase customItem)
    {
        Debug.Log("AddItem");
        if (_itemList[0] != customItem)
            _itemList[0] = Object.Instantiate(customItem);

        _itemList[0].Amount += customItem.Amount;
    }
}