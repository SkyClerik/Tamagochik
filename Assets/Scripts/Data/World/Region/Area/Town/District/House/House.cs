using Hud.Buttons;
using UnityEngine;

namespace Data.World
{
    [CreateAssetMenu(fileName = "House", menuName = "Data/World/House")]
    public class House : NodeBase, IInside, IOutside
    {
        [SerializeField]
        private District _owner;
        public District Owner { get => _owner; set => _owner = value; }

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
                new StartLocationInfo(houseNode: this, entryButton: Entry);
            }
        }

        public void Outside()
        {
            new CreateDistrictUI(district: _owner);
        }

        private void Entry()
        {
            Debug.Log($"Запуск {base.ButtonText}");
            new StartDevelopSpace(startHouse: this);
        }

        public void StartForced()
        {
            Entry();
        }
    }
}