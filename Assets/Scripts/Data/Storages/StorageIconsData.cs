namespace Data.Storages
{
    using UnityEngine;

    [CreateAssetMenu(fileName = "StorageIconsData", menuName = "Data/Storages/IconsData")]
    public class StorageIconsData : ScriptableObject
    {
        [SerializeField] private Sprite _resource;
        [SerializeField] private Sprite _item;
        [SerializeField] private Sprite _prosthesis;
        [SerializeField] private Sprite _furniture;
        [SerializeField] private Sprite _module;
        [SerializeField] private Sprite _hull;
        [SerializeField] private Sprite _barracks;
        [SerializeField] private Sprite _liveRooms;
        [SerializeField] private Sprite _prison;
        [SerializeField] private Sprite _medicalBlock;
        [SerializeField] private Sprite _krioBlock;
        [SerializeField] private Sprite _farms;
        [SerializeField] private Sprite _mine;
        [SerializeField] private Sprite _ederostation;

        public Sprite Resource => _resource;
        public Sprite Item => _item;
        public Sprite Prosthesis => _prosthesis;
        public Sprite Furniture => _furniture;
        public Sprite Module => _module;
        public Sprite Hull => _hull;
        public Sprite Barracks => _barracks;
        public Sprite LiveRooms => _liveRooms;
        public Sprite Prison => _prison;
        public Sprite MedicalBlock => _medicalBlock;
        public Sprite KrioBlock => _krioBlock;
        public Sprite Farms => _farms;
        public Sprite Mine => _mine;
        public Sprite Ederostation => _ederostation;
    }
}