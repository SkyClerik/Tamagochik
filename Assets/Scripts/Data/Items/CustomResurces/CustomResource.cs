namespace Behaviours
{
    using UnityEngine;

    [System.Serializable]
    public class CustomResource : ItemBase
    {
        [SerializeField] private ResourceTypes _resourceType;
        public ResourceTypes ResourceType { get => _resourceType; set => _resourceType = value; }

        public CustomResource(string name, string description, Sprite icon, int amount, ResourceTypes resourceType)
        {
            Name = name;
            Description = description;
            Icon = icon;
            Amount = amount;
            Id = -1;
            _resourceType = resourceType;
        }

        public CustomResource DeepCopy()
        {
            CustomResource clone = (CustomResource)MemberwiseClone();
            clone.Amount = 1;
            return clone;
        }
    }
}