using Data.Item;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;

public class StartInventory
{
    private ItemContainer _inventory;
    private VisualElement _rootVisualElement;
    private List<VisualElement> _slots = new List<VisualElement>();

    public StartInventory()
    {
        GameDataContainer gameDataContainer = GameDataContainer.Instance;
        _inventory = gameDataContainer.GetGameData.Master.Inventory;

        WindowManagement windowManagement = WindowManagement.Instance;
        UIDocument uiDocument = windowManagement.GetInventoryHud;
        uiDocument.enabled = true;

        _rootVisualElement = uiDocument.rootVisualElement;
        ScrollView scrollView = _rootVisualElement.Q<ScrollView>("InventoryScrollView");

        CreateSlots(scrollView, 4, 8);
        List<VisualElement> lines = scrollView.Children().ToList();

        foreach (VisualElement line in lines)
        {
            List<VisualElement> slots = line.Children().ToList();

            for (int i = 0; i < slots.Count; i++)
            {
                _slots.Add(slots[i]);
            }
        }

        for (int i = 0; i < _inventory.ItemList.Length; i++)
        {
            ItemBase item = _inventory.ItemList[i];
            _slots[i].Add(new ItemVisualElement(item, _inventory, i));
        }
    }

    private void CreateSlots(ScrollView scrollView, int slotsInLine, int minLine)
    {
        float needLine = (float)_inventory.ItemList.Length / slotsInLine;
        needLine = Mathf.CeilToInt(needLine);
        needLine = needLine < minLine ? minLine : needLine;

        WindowManagement windowManagement = WindowManagement.Instance;
        VisualTreeAsset itemSlotVisualTree = windowManagement.VtaItemSlotPattern;

        for (int f = 0; f < needLine; f++)
        {
            VisualElement line = new VisualElement();
            line.AddToClassList("items-line");

            for (int i = 0; i < slotsInLine; i++)
            {
                TemplateContainer template = itemSlotVisualTree.Instantiate();
                template.AddToClassList("item-box");
                line.Add(template);
            }

            scrollView.Add(line);
        }
    }
}