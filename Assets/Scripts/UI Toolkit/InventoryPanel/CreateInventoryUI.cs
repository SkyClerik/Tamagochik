using Data.Item;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;

public class CreateInventoryUI
{
    private ItemContainer _inventory;
    private VisualElement _rootVisualElement;
    private List<VisualElement> _slots = new();

    private const string _itemBoxStyle = "item-box";
    private const string _itemBoxLockStyle = "item-box-lock";

    public CreateInventoryUI()
    {
        GameDataContainer gameDataContainer = GameDataContainer.Instance;
        _inventory = gameDataContainer.GetGameData.Master.Inventory;

        WindowManagement windowManagement = WindowManagement.Instance;
        UIDocument uiDocument = windowManagement.GetInventoryDoc;
        uiDocument.enabled = true;

        _rootVisualElement = uiDocument.rootVisualElement;
        ScrollView scrollView = _rootVisualElement.Q<ScrollView>("InventoryScrollView");

        CreateSlots(scrollView, 4, 8);
        List<VisualElement> lines = scrollView.Children().ToList();

        foreach (VisualElement line in lines)
        {
            List<VisualElement> slots = line.Children().ToList();
            for (int i = 0; i < slots.Count; i++)
                _slots.Add(slots[i]);
        }

        for (int i = 0; i < _inventory.ItemList.Length; i++)
        {
            Debug.Log($"�������� ������� �� �����������");
            ItemBase item = _inventory.ItemList[i];
            _slots[i].Add(new ItemVisualElement(item, _inventory, i));
        }

        _inventory.OnItemAdd += EventItemAdd;
    }

    private void EventItemAdd(ItemBase itemBase, int index)
    {
        Debug.Log($"� ��������� �������� ������� {itemBase.Name} � ������ ����� {index}");
        var item = itemBase;
        var childrens = _slots[index].Children().ToList();
        foreach (VisualElement child in childrens)
        {
            if (child is ItemVisualElement)
            {
                var c = (ItemVisualElement)child;
                c.SetItem(item);
            }
        }
    }

    private void CreateSlots(ScrollView scrollView, int slotsInLine, int minLine)
    {
        float needLine = (float)_inventory.ItemList.Length / slotsInLine;
        needLine = Mathf.CeilToInt(needLine);
        needLine = needLine < minLine ? minLine : needLine;

        //WindowManagement windowManagement = WindowManagement.Instance;

        string templateStyle = _itemBoxStyle;
        for (int f = 0, sc = 0; f < needLine; f++)
        {
            VisualElement line = new VisualElement();
            line.AddToClassList("items-line");

            for (int i = 0; i < slotsInLine; i++)
            {
                TemplateContainer template = new TemplateContainer();

                if (sc >= _inventory.ItemList.Length)
                    templateStyle = _itemBoxLockStyle;

                sc++;
                template.AddToClassList(templateStyle);
                line.Add(template);
            }

            scrollView.Add(line);
        }
    }

    public void Hide()
    {
        WindowManagement windowManagement = WindowManagement.Instance;
        UIDocument uiDocument = windowManagement.GetInventoryDoc;
        uiDocument.enabled = false;
    }
}