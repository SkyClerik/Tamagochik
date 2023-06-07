using Data.Units;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CreateRightUI
{
    private Humanoid _master;

    public CreateRightUI()
    {
        _master = GameDataContainer.Instance.GetGameData.Master;

        WindowManagement windowManagement = WindowManagement.Instance;
        UIDocument uiDocument = windowManagement.GetRightDoc;
        uiDocument.enabled = true;

        VisualElement rootVisualelement = uiDocument.rootVisualElement;

        Label avatarNameLable = rootVisualelement.Q<Label>("AvatarNameLable");
        avatarNameLable.text = _master.Name;
    }
}
