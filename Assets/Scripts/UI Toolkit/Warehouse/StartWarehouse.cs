using Data.Item;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;

public class StartWarehouse
{
    private ItemContainer _itemContainer;
    private VisualElement _rootVisualElement;
    private List<VisualElement> _slots = new List<VisualElement>();

    public StartWarehouse()
    {
        GameDataContainer gameDataContainer = GameDataContainer.Instance;
        _itemContainer = gameDataContainer.GetGameData.PlayerWarehouse.GetItemContainer;

        WindowManagement windowManagement = WindowManagement.Instance;
        UIDocument uiDocument = windowManagement.GetWarehouseDocument;
        uiDocument.enabled = true;

        _rootVisualElement = uiDocument.rootVisualElement;
        ScrollView scrollView = _rootVisualElement.Q<ScrollView>("ItemsScrollView");

        CreateSlots(scrollView, 4);
        List<VisualElement> lines = scrollView.Children().ToList();

        foreach (VisualElement line in lines)
        {
            List<VisualElement> slots = line.Children().ToList();

            for (int i = 0; i < slots.Count; i++)
            {
                _slots.Add(slots[i]);
            }
        }

        for (int i = 0; i < _itemContainer.ItemList.Length; i++)
        {
            ItemBase item = _itemContainer.ItemList[i];
            _slots[i].Add(new ItemVisualElement(item, _itemContainer, i));
        }
    }

    private void CreateSlots(ScrollView scrollView, int slotsInLine)
    {
        float needLine = (float)_itemContainer.ItemList.Length / slotsInLine;
        needLine = Mathf.CeilToInt(needLine);

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
