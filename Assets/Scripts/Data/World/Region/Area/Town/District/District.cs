using Hud.Buttons;
using System.Collections.Generic;
using UnityEngine;

namespace Data.World
{
    [CreateAssetMenu(fileName = "District", menuName = "Data/World/District")]
    public class District : NodeBase, IInside, IOutside
    {
        [SerializeField]
        private Town _owner;

        [SerializeField]
        private List<Shop> _shops;

        [SerializeField]
        private List<House> _houses;

        public Town Owner { set { _owner = value; } }
        public List<Shop> Shops { get {  return _shops; } }

        private void OnValidate()
        {
            foreach (var shop in _shops)
                shop.SetOwner = this;

            foreach (var house in _houses)
                house.SetOwner = this;
        }

        public void Inside()
        {
            new CreateDistrictUI(district: this);
        }

        public void Outside()
        {
            _owner.Inside();
        }
    }
}