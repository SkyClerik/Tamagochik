namespace Data.Storages
{
    using UnityEngine;

    [CreateAssetMenu(fileName = "StorageTextsData", menuName = "Data/Storages/TextsData")]
    public class StorageTextsData : ScriptableObject
    {
        [SerializeField] private string _resourceName = "����� ��������";
        [SerializeField] private string _itemName = "����� ���������";
        [SerializeField] private string _prosthesisName = "����� ��������";
        [SerializeField] private string _furnitureName = "����� ������";
        [SerializeField] private string _moduleName = "����� ������������";
        [SerializeField] private string _hullName = "����� ��������";
        [SerializeField] private string _barracksName = "�������";
        [SerializeField] private string _liveRoomsName = "����� �����";
        [SerializeField] private string _prisonName = "�������� ����";
        [SerializeField] private string _medicalBlockName = "��� ����";
        [SerializeField] private string _krioBlockName = "���� ����";
        [SerializeField] private string _farmsName = "�����";
        [SerializeField] private string _mineName = "�����";
        [SerializeField] private string _ederostationName = "������������";

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