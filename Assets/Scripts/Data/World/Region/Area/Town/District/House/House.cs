using Hud.Buttons;
using UnityEngine;

namespace Data.World
{
    [CreateAssetMenu(fileName = "House", menuName = "Data/World/House")]
    public class House : NodeBase, IInside, IOutside
    {
        [SerializeField]
        private District _owner;
        public District SetOwner { set { _owner = value; } }

        public void Inside()
        {
            new StartDevelopSpace(startHouse: this);
        }

        public void Outside()
        {
            _owner.Inside();
        }
    }
}