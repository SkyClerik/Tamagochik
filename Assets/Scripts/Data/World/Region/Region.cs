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
            Debug.Log($"Тык {base.ButtonText}");

            WindowManagement windowManagement = WindowManagement.Instance;
            if (windowManagement.CurrentSelectNode == this)
            {
                Entry();
            }
            else
            {
                windowManagement.CurrentSelectNode = this;
                new StartLocationInfo(regionNode: this, entryButton: Entry);
            }
        }

        public void Outside()
        {
            new CreateWorldUI(worldData: _owner);
        }

        private void Entry()
        {
            Debug.Log($"Запуск {base.ButtonText}");
            new CreateRegionUI(region: this);
        }
    }
}