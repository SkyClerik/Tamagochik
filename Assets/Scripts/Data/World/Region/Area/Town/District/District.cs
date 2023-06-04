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

        public Town Owner { get => _owner; set => _owner = value; }
        public List<Shop> Shops { get { return _shops; } }

        private void OnValidate()
        {
            foreach (var shop in _shops)
                shop.Owner = this;

            foreach (var house in _houses)
                house.Owner = this;
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
                new StartLocationInfo(districtNode: this, entryButton: Entry);
            }
        }

        public void Outside()
        {
            new CreateTownUI(town: _owner);
        }

        private void Entry()
        {
            Debug.Log($"Запуск {base.ButtonText}");
            new CreateDistrictUI(district: this);
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
                new StartLocationInfo(districtNode: this, entryButton: Outside);
            }
        }
    }
}