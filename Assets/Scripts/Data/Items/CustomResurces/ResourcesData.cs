namespace Data.Resources
{
    using Behaviours;
    using System.Collections.Generic;
    using UnityEngine;

    [CreateAssetMenu(fileName = "ResourcesData", menuName = "Data/Resources/ResourcesData")]
    public class ResourcesData : ScriptableObject
    {
        [SerializeField]
        private List<CustomResource> _resources;
        public List<CustomResource> Resources { get => _resources; set => _resources = value; }

        public void Calculate(ResourceTextsData resourceTextsData, ResourceIconsData resourceIconsData)
        {
            Debug.Log($"Calculate");
            _resources = new List<CustomResource>()
            {
                new CustomResource(resourceTextsData.Iron_name, resourceTextsData.Iron_Description, resourceIconsData.Iron, amount: 0, ResourceTypes.Iron),
                new CustomResource(resourceTextsData.Wood_name, resourceTextsData.Wood_Description, resourceIconsData.Wood, amount: 0, ResourceTypes.Wood),
                new CustomResource(resourceTextsData.Gold_name, resourceTextsData.Gold_Description, resourceIconsData.Gold, amount: 0, ResourceTypes.Gold),
                new CustomResource(resourceTextsData.Stone_name, resourceTextsData.Stone_Description, resourceIconsData.Stone, amount: 0, ResourceTypes.Stone),
            };

            // Auto generate index
            for (int i = 0; i < _resources.Count; i++)
            {
                _resources[i].Id = i;
            }
        }

        public CustomResource GetResourceBase(ResourceTypes resourceTypes)
        {
            for (int i = 0; i < _resources.Count; i++)
            {
                if (_resources[i].ResourceType == resourceTypes)
                {
                    return _resources[i];
                }
            }
            return null;
        }
    }
}