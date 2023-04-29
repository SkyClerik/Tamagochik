namespace Data.Storages
{
    using UnityEngine;

    [CreateAssetMenu(fileName = "StorageTextsData", menuName = "Data/Storages/TextsData")]
    public class StorageTextsData : ScriptableObject
    {
        [SerializeField] private string _resourceName = "Склад ресурсов";
        [SerializeField] private string _itemName = "Склад предметов";
        [SerializeField] private string _prosthesisName = "Склад протезов";
        [SerializeField] private string _furnitureName = "Склад мебели";
        [SerializeField] private string _moduleName = "Склад оборудования";
        [SerializeField] private string _hullName = "Склад корпусов";
        [SerializeField] private string _barracksName = "Казармы";
        [SerializeField] private string _liveRoomsName = "Жилые блоки";
        [SerializeField] private string _prisonName = "Тюремный блок";
        [SerializeField] private string _medicalBlockName = "Мед блок";
        [SerializeField] private string _krioBlockName = "Крио блок";
        [SerializeField] private string _farmsName = "Ферма";
        [SerializeField] private string _mineName = "Шахта";
        [SerializeField] private string _ederostationName = "Эдеростанция";

        public string ResourceName => _resourceName;
        public string ItemName => _itemName;
        public string ProsthesisName => _prosthesisName;
        public string FurnitureName => _furnitureName;
        public string ModuleName => _moduleName;
        public string HullName => _hullName;
        public string BarracksName => _barracksName;
        public string LiveRoomsName => _liveRoomsName;
        public string PrisonName => _prisonName;
        public string MedicalBlockName => _medicalBlockName;
        public string KrioBlockName => _krioBlockName;
        public string FarmsName => _farmsName;
        public string MineName => _mineName;
        public string EderostationName => _ederostationName;
    }
}