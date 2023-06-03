using Hud.Buttons;
using System.Collections.Generic;
using UnityEngine;

namespace Data.World
{
    [CreateAssetMenu(fileName = "WorldData", menuName = "Data/World/WorldData")]
    public class WorldData : ScriptableObject, IInside
    {
        [SerializeField]
        private string _title;
        [SerializeField]
        private List<Region> _regions;

        public string GetTitle => _title;
        public List<Region> Regions => _regions;

        public void Inside()
        {
            new CreateWorldUI(worldData: this);
        }

        private void OnValidate()
        {
            foreach (var region in _regions)
                region.Owner = this;
        }
    }
}