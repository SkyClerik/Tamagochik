using Hud.Buttons;
using UnityEngine;

namespace Data.World
{
    [CreateAssetMenu(fileName = "Shop", menuName = "Data/World/Shop")]
    public class Shop : NodeBase, IInside, IOutside
    {
        [SerializeField]
        private District _owner;
        public District Owner { get => _owner; set => _owner = value; }

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
                new StartLocationInfo(shopNode: this, entryButton: Entry);
            }
        }

        public void Outside()
        {
            new CreateDistrictUI(district: _owner);
        }

        private void Entry()
        {
            Debug.Log($"Запуск {base.ButtonText}");
        }
    }
}