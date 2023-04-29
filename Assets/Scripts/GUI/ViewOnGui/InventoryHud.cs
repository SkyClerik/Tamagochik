using Data.Rects;
using Data.Units;
using UnityEngine;

public class InventoryHud : MonoBehaviour
{
    private Rect _equpmentArea;
    private Rect _inventoryArea;
    private RectsData _rectsData;
    private GUISkin _guiSkin;

    private Rect[] _inventorySlots;
    private Humanoid _humanoid;
    private Inventory _inventory;

    private void Start()
    {
        var gameDataContainer = GameDataContainer.Instance;
        _rectsData = gameDataContainer.GetRectsData;
        _guiSkin = gameDataContainer.StandartGuiSkin;
        var rightArea = _rectsData.RightArea;
        _equpmentArea = rightArea;
        _equpmentArea.height = _equpmentArea.width;

        _inventoryArea = rightArea;
        _inventoryArea.height -= _equpmentArea.height;
        _inventoryArea.y = _equpmentArea.yMax;

        enabled = false;
    }

    public void Init(Humanoid humanoid)
    {
        _humanoid = humanoid;
        _inventory = humanoid.Inventory;
        _inventorySlots = new Rect[_inventory.ItemList.Length];

        int colomn = 0;
        int line = 0;
        int slotSize = 60;
        for (int i = 0; i < _inventory.ItemList.Length; i++)
        {
            _inventorySlots[i] = new Rect(colomn * slotSize, line * slotSize, slotSize, slotSize);

            colomn++;
            if (colomn == 4)
            {
                colomn = 0;
                line++;
            }
        }

        enabled = true;
    }

    private void OnGUI()
    {
        GUI.skin = _guiSkin;
        ViewEquipment();
        ViewInventory();
    }

    private void ViewEquipment()
    {
        GUI.Box(_equpmentArea, string.Empty);
        GUILayout.BeginArea(_equpmentArea);

        GUILayout.Box(_humanoid.Name);

        GUILayout.EndArea();
    }

    private void ViewInventory()
    {
        GUI.Box(_inventoryArea, string.Empty);
        GUILayout.BeginArea(_inventoryArea);

        for (int i = 0; i < _inventorySlots.Length; i++)
        {
            GUI.Box(_inventorySlots[i], "");
        }

        for (int i = 0; i < _inventory.ItemList.Length; i++)
        {
            if (!string.IsNullOrEmpty(_inventory.ItemList[i].Name))
            {
                if (GUI.Button(_inventorySlots[i], $"{_inventory.ItemList[i].Name}\n{_inventory.ItemList[i].Amount}"))
                { }
            }
        }

        GUILayout.EndArea();
    }
}