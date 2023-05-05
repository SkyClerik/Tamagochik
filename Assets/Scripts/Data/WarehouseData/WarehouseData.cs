using UnityEngine;

[CreateAssetMenu(fileName = "WarehouseData", menuName = "Data/WarehouseData")]
public class WarehouseData : ScriptableObject
{
    [SerializeField]
    private ItemContainer _itemContainer;
    public ItemContainer GetItemContainer => _itemContainer;
}
