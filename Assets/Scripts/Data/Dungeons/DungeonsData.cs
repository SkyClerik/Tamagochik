namespace Data.Dungeon
{
    using System.Collections.Generic;
    using UnityEngine;
    using Behaviours;
    using Data.Resources;

    [CreateAssetMenu(fileName = "DungeonsData", menuName = "Data/Dungeons/DungeonsData")]
    public class DungeonsData : ScriptableObject
    {
        [SerializeField]
        private List<Dungeon> _dungeons;
        public List<Dungeon> Dungeons { get => _dungeons; set => _dungeons = value; }

        public void Calculate(DungeonTextsData dungeonTexts, DungeonIconsData dungeonIcons, ResourcesData resourcesData)
        {
            Debug.Log($"Calculate");

            _dungeons = new List<Dungeon>()
            {
                new Dungeon(dungeonIcons.Dungeon_1, dungeonTexts.Dungeon_1_Name, kDTime: 1,
                    new List<LutInfo> ()
                    {
                        new LutInfo(ResourceTypes.Iron ,amount: 2),
                        new LutInfo(ResourceTypes.Wood ,amount: 4),
                    }),

                new Dungeon(dungeonIcons.Dungeon_2, dungeonTexts.Dungeon_2, 2, null),

                new Dungeon(dungeonIcons.Dungeon_3, dungeonTexts.Dungeon_3, 4, null),

                new Dungeon(dungeonIcons.Dungeon_4, dungeonTexts.Dungeon_4, 6, null),
            };
        }
    }
}