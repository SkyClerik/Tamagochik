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

        public Area SetOwner { set { _owner = value; } }
        public List<District> Districts => _districts;

        private void OnValidate()
        {
            foreach (var district in _districts)
                district.Owner = this;
        }

        public void Inside()
        {
            new CreateTownUI(town: this);
        }

        public void Outside()
        {
            _owner.Inside();
        }
    }
}