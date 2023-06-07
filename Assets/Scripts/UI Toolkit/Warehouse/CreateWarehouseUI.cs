using Data.Item;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;

public class CreateWarehouseUI
{
    private ItemContainer _itemContainer;
    private UIDocument _uiDocument;
    private VisualElement _rootVisualElement;
    private List<VisualElement> _slots = new List<VisualElement>();

    public CreateWarehouseUI(System.Action callback)
    {
        GameDataContainer gameDataContainer = GameDataContainer.Instance;
        _itemContainer = gameDataContainer.GetGameData.PlayerWarehouse.GetItemContainer;

        WindowManagement windowManagement = WindowManagement.Instance;
        _uiDocument = windowManagement.GetWarehouseDoc;
        _uiDocument.enabled = true;

        _rootVisualElement = _uiDocument.rootVisualElement;
        _rootVisualElement.Q<Button>("BackButton").clicked += callback;
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

        for (int f = 0; f < needLine; f++)
        {
            VisualElement line = new VisualElement();
            line.AddToClassList("items-line");

            for (int i = 0; i < slotsInLine; i++)
            {
                TemplateContainer template = new TemplateContainer();
                template.AddToClassList("item-box");
                line.Add(template);
            }

            scrollView.Add(line);
        }
    }

    public void Hide()
    {
        _uiDocument.enabled = false;
    }
}
