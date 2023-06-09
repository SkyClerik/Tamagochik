using UnityEngine;

[System.Serializable]
public class UnitBase : ScriptableObject
{
    [SerializeField] private int _staticID;
    [SerializeField] private string _name;
    [SerializeField] private Sprite _icon;
    [SerializeField] private int _energy;
    [SerializeField] private bool _busy = false;
    [SerializeField] private bool _visible = true;

    public int StaticID { get => _staticID; set => _staticID = value; }
    public string Name { get => _name; set => _name = value; }
    public Sprite Icon { get => _icon; set => _icon = value; }
    public int Energy { get => _energy; set => _energy = value; }
    public bool Busy { get => _busy; set => _busy = value; }
    public bool Visible { get => _visible; set => _visible = value; }

    private void OnValidate()
    {
        _staticID = GetInstanceID();
    }
}
