using Hud.Buttons;
using System.Collections.Generic;
using UnityEngine;

namespace Data.World
{
    [CreateAssetMenu(fileName = "WorldData", menuName = "Data/World/WorldData")]
    public class WorldData : ScriptableObject, IInside
    {
        [SerializeField]
        private List<Region> _regions;

        public List<Region> Regions => _regions;

        public void Inside()
        {
            new CreateWorldUI(worldData: this);
        }

        private void OnValidate()
        {
            foreach (var region in _regions)
                region.SetOwner = this;
        }
    }
}