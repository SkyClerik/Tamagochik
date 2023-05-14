using Data.Item;
using Data.Units;
using System.Collections.Generic;
using UnityEngine;

namespace Data.World
{

    [System.Serializable]
    [CreateAssetMenu(fileName = "Dungeon", menuName = "Data/World/Dungeon")]
    public class Dungeon : NodeBase, IInside, IOutside
    {
        [SerializeField]
        private Area _owner;
        [SerializeField]
        private string _name;
        [SerializeField]
        private bool _busy = false;
        [SerializeField]
        private bool _visible = true;
        [Header("Количество дней для выполнения")]
        [SerializeField]
        private int _startKDTime;
        private int _currentKDTime;
        [SerializeField]
        private LutData _lutData;

        private List<UnitBase> _party = new List<UnitBase>();
        private int _currentWaitTime;

        public Area SetOwner { set { _owner = value; } }
        public string Name { get => _name; set => _name = value; }
        public bool Busy { get => _busy; set => _busy = value; }
        public bool Visible { get => _visible; set => _visible = value; }
        public int StartKDTime { get => _startKDTime; set => _startKDTime = value; }
        public int CurrentKDTime { get => _currentKDTime; set => _currentKDTime = value; }
        public LutData GetLutData => _lutData;
        public List<UnitBase> Party { get => _party; set => _party = value; }
        public int CurrentWaitTime { get => _currentWaitTime; set => _currentWaitTime = value; }

        public void Inside()
        {
            var windowManagement = WindowManagement.Instance;
            windowManagement.GetGeneralButtons.enabled = false;
            windowManagement.GetRightHud.enabled = false;
            new StartClicker(dungeon: this);
            new StartInventory();
        }

        public void Outside()
        {
            _owner.Inside();
        }

        public void StartQuest()
        {
            GameDataContainer.Instance.GetGameData.OnDayPassed += OnDayPassedAction;
            _currentKDTime = StartKDTime;
            _busy = true;
        }

        private void OnDayPassedAction()
        {
            if (_busy is true)
                _currentKDTime--;

            if (_currentKDTime <= 0)
            {
                _busy = false;
                GameDataContainer.Instance.GetGameData.OnDayPassed -= OnDayPassedAction;

                for (int i = 0; i < _party.Count; i++)
                {
                    _party[i].Busy = false;
                }
            }
        }
    }
}