using UnityEngine;

namespace Data.World
{
    [CreateAssetMenu(fileName = "Shop", menuName = "Data/World/Shop")]
    public class Shop : NodeBase, IInside, IOutside
    {
        [SerializeField]
        private District _owner;
        public District SetOwner { set { _owner = value; } }

        public void Inside()
        {
            Debug.Log($"Запуск {base.ButtonText}");
        }

        public void Outside()
        {
            _owner.Inside();
        }
    }
}