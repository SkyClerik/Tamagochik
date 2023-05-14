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

        public Region SetOwner { set { _owner = value; } }
        public List<Town> Towns => _towns;
        public List<Dungeon> Dungeons => _dungeons;

        private void OnValidate()
        {
            foreach (var town in _towns)
                town.SetOwner = this;

            foreach (var dungeons in _dungeons)
                dungeons.SetOwner = this;
        }

        public void Inside()
        {
            new CreateAreaUI(area: this);
        }

        public void Outside()
        {
            _owner.Inside();
        }
    }
}