using Hud.Buttons;
using System.Collections.Generic;
using UnityEngine;

namespace Data.World
{
    [CreateAssetMenu(fileName = "Area", menuName = "Data/World/Area")]
    public class Area : NodeBase, IInside, IOutside
    {
        [SerializeField]
        private Region _owner;
        [SerializeField]
        private List<Town> _towns;
        [SerializeField]
        private List<Dungeon> _dungeons;

        public Region Owner { get => _owner; set => _owner = value; }
        public List<Town> Towns => _towns;
        public List<Dungeon> Dungeons => _dungeons;

        private void OnValidate()
        {
            foreach (var town in _towns)
                town.Owner = this;

            foreach (var dungeons in _dungeons)
                dungeons.Owner = this;
        }

        public void Inside()
        {
            Debug.Log($"Тык {base.ButtonText}");

            WorldData worldData = GameDataContainer.Instance.GetWorldData;
            if (worldData.IsEquilsCurSelect(this))
            {
                Entry();
            }
            else
            {
                new StartLocationInfo(areaNode: this, entryButton: Entry);
            }
        }

        public void Outside()
        {
            new CreateRegionUI(region: _owner);
        }

        private void Entry()
        {
            Debug.Log($"Запуск {base.ButtonText}");
            new CreateAreaUI(area: this);
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
                new StartLocationInfo(areaNode: this, entryButton: Outside);
            }
        }
    }
}