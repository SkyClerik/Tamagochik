using Hud.Buttons;
using System.Collections.Generic;
using UnityEngine;

namespace Data.World
{
    [CreateAssetMenu(fileName = "Region", menuName = "Data/World/Region")]
    public class Region : NodeBase, IInside, IOutside
    {
        [SerializeField]
        private WorldData _owner;
        [SerializeField]
        private List<Area> _areas;

        public WorldData SetOwner { set { _owner = value; } }
        public List<Area> Areas => _areas;

        private void OnValidate()
        {
            foreach (var area in _areas)
                area.SetOwner = this;
        }

        public void Inside()
        {
            new CreateRegionUI(region: this);
        }

        public void Outside()
        {
            _owner.Inside();
        }
    }
}