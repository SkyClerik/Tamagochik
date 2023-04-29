using UnityEngine;

namespace Behaviours
{
    [System.Serializable]
    public class LutInfo
    {
        [SerializeField] private ResourceTypes _resourceType;
        [SerializeField] private int _itemId;
        [SerializeField] private int _amount;

        public ResourceTypes GetResourceType => _resourceType;
        public int GetItemId => _itemId;
        public int GetAmount => _amount;

        public LutInfo(ResourceTypes resourceType, int amount)
        {
            _resourceType = resourceType;
            _itemId = -1;
            _amount = amount;
        }

        public LutInfo(int itemId, int amount)
        {
            _resourceType = ResourceTypes.None;
            _itemId = itemId;
            _amount = amount;
        }
    }
}