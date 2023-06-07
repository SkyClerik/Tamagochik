using Data.Item;
using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using static UnityEditor.Progress;

[System.Serializable]
public class ItemContainer
{
    [SerializeField]
    private ItemBase[] _itemList;
    public ItemBase[] ItemList { get => _itemList; set => _itemList = value; }

    public Action<ItemBase, int> OnItemAdd;

    public bool TryAddItem(ItemBase customItem, int ammount)
    {
        Debug.Log($"AddItem {customItem.Name} in ammount {ammount}");

        if (GetEquils(customItem, out int index))
        {
            AddAmmount(customItem, ammount, index);
            return true;
        }
        else
        {
            if (GetEmpty(out index) is true)
            {
                _itemList[index] = customItem.Clone();
                AddAmmount(customItem, ammount, index);
                return true;
            }
            else
            {
                Debug.Log($"в инвентаре нет места");
                return false;
            }
        }
    }

    private void AddAmmount(ItemBase customItem, int ammount, int index)
    {
        var surplus = TryAddAmmount(_itemList[index], ammount);
        OnItemAdd?.Invoke(_itemList[index], index);
        if (surplus != 0)
            TryAddItem(customItem, surplus);
    }

    private int TryAddAmmount(ItemBase item, int ammount)
    {
        var num = ammount + item.Amount;
        var surplus = 0;
        if (num > item.MaxAmount)
        {
            surplus = num - item.MaxAmount;
            item.Amount = item.MaxAmount;
        }
        else
        {
            item.Amount += ammount;
        }
        return surplus;
    }

    private bool GetEquils(ItemBase itemBase, out int index)
    {
        index = 0;
        for (int i = 0; i < _itemList.Length; i++)
        {
            if (_itemList[i] != null)
            {
                Debug.Log($"item id {_itemList[i].Id}");
                if (itemBase.Id == _itemList[i].Id)
                {
                    if (_itemList[i].Amount < _itemList[i].MaxAmount)
                    {
                        index = i;
                        return true;
                    }
                }
            }
        }
        return false;
    }

    private bool GetEmpty(out int index)
    {
        index = 0;
        for (int i = 0; i < _itemList.Length; i++)
        {
            if (ItemList[i] == null)
            {
                index = i;
                return true;
            }
        }
        return false;
    }
}