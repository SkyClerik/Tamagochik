using Data.World;
using System;
using UnityEngine;
using UnityEngine.UIElements;

public class StartLocationInfo
{
    private UIDocument _uiDocument;
    private VisualElement _rootVisualElement;

    public StartLocationInfo(Shop shopNode, Action callback)
    {
        Debug.Log("Shop");
        AwakeInit(callback);
        Init(shopNode);
    }

    public StartLocationInfo(House houseNode, Action callback)
    {
        Debug.Log("House");
        AwakeInit(callback);
        Init(houseNode);
    }

    public StartLocationInfo(Town townNode, Action callback)
    {
        Debug.Log("Town");
        AwakeInit(callback);
        Init(townNode);
    }

    public StartLocationInfo(District districtNode, Action callback)
    {
        Debug.Log("District");
        AwakeInit(callback);
        Init(districtNode);
    }

    public StartLocationInfo(Region regionNode, Action callback)
    {
        Debug.Log("Region");
        AwakeInit(callback);
        Init(regionNode);
    }

    public StartLocationInfo(Area areaNode, Action callback)
    {
        Debug.Log("Region");
        AwakeInit(callback);
        Init(areaNode);
    }

    public StartLocationInfo(Dungeon dungeonNode, Action callback)
    {
        Debug.Log("Dungeon");
        AwakeInit(callback);
        Init(dungeonNode);
    }

    private void AwakeInit(Action callback)
    {
        WindowManagement windowManagement = WindowManagement.Instance;
        _uiDocument = windowManagement.GetLocationInfoDoc;
        _uiDocument.enabled = true;
        _rootVisualElement = _uiDocument.rootVisualElement;

        Button enterButton = _rootVisualElement.Q<Button>("EnterButton");
        enterButton.clicked += callback;
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
