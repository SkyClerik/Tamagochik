namespace Data.Dungeon
{
    using UnityEngine;

    [CreateAssetMenu(fileName = "DungeonTextsData", menuName = "Data/Dungeons/DungeonTextsData")]
    public class DungeonTextsData : ScriptableObject
    {
        [SerializeField] private string _dungeon_1 = "Холмы троллей";
        [SerializeField] private string _dungeon_2 = "Роща жалообразов";
        [SerializeField] private string _dungeon_3 = "Плетеный лес";
        [SerializeField] private string _dungeon_4 = "За бескрайним морем";
        public string Dungeon_1_Name => _dungeon_1;
        public string Dungeon_2 => _dungeon_2;
        public string Dungeon_3 => _dungeon_3;
        public string Dungeon_4 => _dungeon_4;
    }
}