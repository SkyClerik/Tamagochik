[System.Serializable]
public enum SoundType : byte
{
    Effect,
    Music
}

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

[System.Serializable]
public enum ProsthesisTypes : byte
{
    None,
    Head,
    LeftArm,
    RightArm,
    Torso,
    LeftLeg,
    RightLeg,
}

[System.Serializable]
public enum ResourceTypes : byte
{
    None,
    Iron,
    Wood,
    Gold,
    Stone,
}

[System.Serializable]
public enum DataTypes : byte
{
    Item,
    Resource,
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