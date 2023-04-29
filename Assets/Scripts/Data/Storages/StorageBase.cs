namespace Behaviours
{
    using UnityEngine;

    [System.Serializable]

    public class StorageBase
    {
        [SerializeField] private string _name;
        [SerializeField] private Sprite _icon;
        [SerializeField] private bool _visible = true;
        [SerializeField] private StorageTypes _storageType;

        public string Name { get => _name; set => _name = value; }
        public Sprite Icon { get => _icon; set => _icon = value; }
        public bool Visible { get => _visible; set => _visible = value; }
        public StorageTypes StorageType { get => _storageType; set => _storageType = value; }

        public StorageBase(string name, Sprite icon, bool visible, StorageTypes storageType)
        {
            _name = name;
            _icon = icon;
            _visible = visible;
            _storageType= storageType;
        }
    }
}