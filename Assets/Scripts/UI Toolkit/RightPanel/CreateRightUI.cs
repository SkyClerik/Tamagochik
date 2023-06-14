using Data.Units;
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

        VisualElement rootVisualElement = uiDocument.rootVisualElement;

        Label avatarNameLabel = rootVisualElement.Q<Label>("AvatarNameLabel");
        avatarNameLabel.text = _master.Name;
    }
}
