namespace Data.Dungeon
{
    using System.Collections.Generic;
    using UnityEngine;
    using Behaviours;

    [CreateAssetMenu(fileName = "DungeonsData", menuName = "Data/Dungeons/DungeonsData")]
    public class DungeonsData : ScriptableObject
    {
        [SerializeField]
        private List<Dungeon> _dungeons;
        public List<Dungeon> Dungeons => _dungeons;
    }
}