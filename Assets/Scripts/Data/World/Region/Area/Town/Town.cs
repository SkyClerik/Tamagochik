using Hud.Buttons;
using System.Collections.Generic;
using UnityEngine;

namespace Data.World
{
    [CreateAssetMenu(fileName = "Town", menuName = "Data/World/Town")]
    public class Town : NodeBase, IInside, IOutside
    {
        [SerializeField]
        private Area _owner;
        [SerializeField]
        private List<District> _districts;

        public Area Owner { get => _owner; set => _owner = value; }
        public List<District> Districts => _districts;

        private void OnValidate()
        {
            foreach (var district in _districts)
                district.Owner = this;
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
                new StartLocationInfo(townNode: this, callback: Entry);
            }
        }

        public void Outside()
        {
            new CreateAreaUI(area: _owner);
        }

        private void Entry()
        {
            Debug.Log($"Запуск {base.ButtonText}");
            new CreateTownUI(town: this);
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
                new StartLocationInfo(townNode: this, callback: Outside);
            }
        }
    }
}