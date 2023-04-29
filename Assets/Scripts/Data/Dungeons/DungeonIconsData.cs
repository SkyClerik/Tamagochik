namespace Data.Dungeon
{
    using UnityEngine;

    [CreateAssetMenu(fileName = "DungeonIconsData", menuName = "Data/Dungeons/DungeonIconsData")]
    public class DungeonIconsData : ScriptableObject
    {
        [SerializeField] private Sprite _dungeon_1;
        [SerializeField] private Sprite _dungeon_2;
        [SerializeField] private Sprite _dungeon_3;
        [SerializeField] private Sprite _dungeon_4;
        public Sprite Dungeon_1 => _dungeon_1;
        public Sprite Dungeon_2 => _dungeon_2;
        public Sprite Dungeon_3 => _dungeon_3;
        public Sprite Dungeon_4 => _dungeon_4;

    }
}