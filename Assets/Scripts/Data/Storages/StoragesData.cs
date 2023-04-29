namespace Data.Storages
{
    using System.Collections.Generic;
    using UnityEngine;
    using Behaviours;

    [CreateAssetMenu(fileName = "StoragesData", menuName = "Data/Storages/StoragesData")]
    public class StoragesData : ScriptableObject
    {
        [SerializeField]
        private List<StorageBase> _storageBase;
        public List<StorageBase> Storages { get => _storageBase; set => _storageBase = value; }

        public void Calculate(StorageTextsData storageTextsData, StorageIconsData storageIconsData)
        {
            Debug.Log($"Calculate");
            _storageBase = new List<StorageBase>()
            {
                new StorageBase(storageTextsData.ResourceName , storageIconsData.Resource, visible: true, StorageTypes.Resource),
                new StorageBase(storageTextsData.ItemName, storageIconsData.Item, visible: true, StorageTypes.Item),
                new StorageBase(storageTextsData.ProsthesisName , storageIconsData.Prosthesis, visible: true, StorageTypes.Prosthesis),
                new StorageBase(storageTextsData.FurnitureName , storageIconsData.Furniture, visible: true, StorageTypes.Furniture),
                new StorageBase(storageTextsData.ModuleName , storageIconsData.Module, visible: true, StorageTypes.Module),
                new StorageBase(storageTextsData.HullName , storageIconsData.Hull, visible: true, StorageTypes.Hull),
                new StorageBase(storageTextsData.BarracksName , storageIconsData.Barracks, visible: true, StorageTypes.Barracks),
                new StorageBase(storageTextsData.LiveRoomsName , storageIconsData.LiveRooms, visible: true, StorageTypes.LiveRooms),
                new StorageBase(storageTextsData.PrisonName , storageIconsData.Prison, visible: true, StorageTypes.Prison),
                new StorageBase(storageTextsData.MedicalBlockName , storageIconsData.MedicalBlock, visible: true, StorageTypes.MedicalBlock),
                new StorageBase(storageTextsData.KrioBlockName , storageIconsData.KrioBlock, visible: true, StorageTypes.KrioBlock),
                new StorageBase(storageTextsData.FarmsName , storageIconsData.Farms, visible: true, StorageTypes.Farms),
                new StorageBase(storageTextsData.MineName , storageIconsData.Mine, visible: true, StorageTypes.Mine),
                new StorageBase(storageTextsData.EderostationName , storageIconsData.Ederostation, visible: true, StorageTypes.Ederostation),
            };
        }
    }
}