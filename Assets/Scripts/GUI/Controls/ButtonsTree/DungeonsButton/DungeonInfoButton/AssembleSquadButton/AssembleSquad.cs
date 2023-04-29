namespace Hud.Buttons
{
    using Behaviours;

    public class AssembleSquad : IInit
    {
        private Dungeon _dungeon;

        public void Init(params object[] list)
        {
            _dungeon = list[0] as Dungeon;

            WindowManagement.Instance.GetAssembleSquadHud.Init(BackButton, _dungeon);
        }

        private void BackButton()
        {
            WindowManagement.Instance.GetAssembleSquadHud.enabled = false;
            new DungeonInfo().Init(_dungeon);
        }
    }
}