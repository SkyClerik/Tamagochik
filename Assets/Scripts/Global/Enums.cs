//TODO заглушки
[System.Serializable]
public enum HorizontalDirection : int
{
    Left = -1,
    Right = 1,
}

[System.Serializable]
public enum EquipTypes : byte
{
    None,
    Head,
    LeftArm,
    RightArm,
    Torso,
    Feet,
}

public enum StorageTypes : byte
{
    Item,
    Resource,
    Prosthesis,
    Furniture,
    Module,
    Hull,
    Barracks,
    LiveRooms,
    Prison,
    MedicalBlock,
    KrioBlock,
    Farms,
    Mine,
    Ederostation
}