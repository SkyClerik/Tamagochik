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

        public WorldData Owner { get => _owner; set => _owner = value; }
        public List<Area> Areas => _areas;

        private void OnValidate()
        {
            foreach (var area in _areas)
                area.Owner = this;
        }

        public void Inside()
        {
            Debug.Log($"��� {base.ButtonText}");
            WorldData worldData = GameDataContainer.Instance.GetWorldData;
            if (worldData.IsEquilsCurSelect(this))
            {
                Entry();
            }
            else
            {
                new StartLocationInfo(regionNode: this, entryButton: Entry);
            }
        }

        public void Outside()
        {
            new CreateWorldUI(worldData: _owner);
        }

        private void Entry()
        {
            Debug.Log($"������ {base.ButtonText}");
            new CreateRegionUI(region: this);
        }

        public void EntryBackList()
        {
            WorldData worldData = GameDataContainer.Instance.GetWorldData;
            if (worldData.IsEquilsCurSelect(this))
            {
                Outside();
            }
            else
            {
                new StartLocationInfo(regionNode: this, entryButton: Outside);
            }
        }
    }
}