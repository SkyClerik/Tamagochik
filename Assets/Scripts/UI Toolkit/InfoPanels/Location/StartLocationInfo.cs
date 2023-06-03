using Data.World;
using System;
using UnityEngine;
using UnityEngine.UIElements;

public class StartLocationInfo
{
    private UIDocument _uiDocument;
    private VisualElement _rootVisualElement;

    public StartLocationInfo(Shop shopNode, Action entryButton)
    {
        Debug.Log("Shop");
        AwakeInit(entryButton);
        Init(shopNode);
    }

    public StartLocationInfo(House houseNode, Action entryButton)
    {
        Debug.Log("House");
        AwakeInit(entryButton);
        Init(houseNode);
    }

    public StartLocationInfo(Town townNode, Action entryButton)
    {
        Debug.Log("Town");
        AwakeInit(entryButton);
        Init(townNode);
    }

    public StartLocationInfo(District districtNode, Action entryButton)
    {
        Debug.Log("District");
        AwakeInit(entryButton);
        Init(districtNode);
    }

    public StartLocationInfo(Region regionNode, Action entryButton)
    {
        Debug.Log("Region");
        AwakeInit(entryButton);
        Init(regionNode);
    }

    public StartLocationInfo(Area areaNode, Action entryButton)
    {
        Debug.Log("Region");
        AwakeInit(entryButton);
        Init(areaNode);
    }

    public StartLocationInfo(Dungeon dungeonNode, Action entryButton)
    {
        Debug.Log("Dungeon");
        AwakeInit(entryButton);
        Init(dungeonNode);
    }

    private void AwakeInit(Action entryButton)
    {
        WindowManagement windowManagement = WindowManagement.Instance;
        _uiDocument = windowManagement.GetLocationInfo;
        _uiDocument.enabled = true;
        _rootVisualElement = _uiDocument.rootVisualElement;

        Button enterButton = _rootVisualElement.Q<Button>("EnterButton");
        enterButton.clicked += entryButton;
    }

    private void Init(Shop shopNode)
    {
        Label ownerTitle = _rootVisualElement.Q<Label>("OwnerTitle");
        Label title = _rootVisualElement.Q<Label>("Title");
        ownerTitle.text = shopNode.Owner.GetTitle;
        title.text = shopNode.GetTitle;
    }

    private void Init(House houseNode)
    {
        Label ownerTitle = _rootVisualElement.Q<Label>("OwnerTitle");
        Label title = _rootVisualElement.Q<Label>("Title");
        ownerTitle.text = houseNode.Owner.GetTitle;
        title.text = houseNode.GetTitle;
    }

    private void Init(Town townNode)
    {
        Label ownerTitle = _rootVisualElement.Q<Label>("OwnerTitle");
        Label title = _rootVisualElement.Q<Label>("Title");
        ownerTitle.text = townNode.Owner.GetTitle;
        title.text = townNode.GetTitle;
    }

    private void Init(District districtNode)
    {
        Label ownerTitle = _rootVisualElement.Q<Label>("OwnerTitle");
        Label title = _rootVisualElement.Q<Label>("Title");
        ownerTitle.text = districtNode.Owner.GetTitle;
        title.text = districtNode.GetTitle;
    }

    private void Init(Region regionNode)
    {
        Label ownerTitle = _rootVisualElement.Q<Label>("OwnerTitle");
        Label title = _rootVisualElement.Q<Label>("Title");
        ownerTitle.text = regionNode.Owner.GetTitle;
        title.text = regionNode.GetTitle;
    }

    private void Init(Area areaNode)
    {
        Label ownerTitle = _rootVisualElement.Q<Label>("OwnerTitle");
        Label title = _rootVisualElement.Q<Label>("Title");
        ownerTitle.text = areaNode.Owner.GetTitle;
        title.text = areaNode.GetTitle;
    }

    private void Init(Dungeon dungeonNode)
    {
        Label ownerTitle = _rootVisualElement.Q<Label>("OwnerTitle");
        Label title = _rootVisualElement.Q<Label>("Title");
        ownerTitle.text = dungeonNode.Owner.GetTitle;
        title.text = dungeonNode.GetTitle;
    }
}
