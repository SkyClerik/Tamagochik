namespace Behaviours
{
    using Data.Units;
    using System.Collections.Generic;
    using UnityEngine;

    [System.Serializable]
    public class Dungeon
    {
        [SerializeField] private string _name;
        [SerializeField] private Sprite _icon;
        [SerializeField] private bool _busy = false;
        [SerializeField] private bool _visible = true;
        [Header("Начальное время требуемое провести в подземелье")]
        [SerializeField] private int _kDTime;
        [SerializeField] private int _currentKDTime;
        [Header("Добываемые в подземелье ресурсы")]
        [SerializeField] private List<LutInfo> _lutInfo;

        private List<UnitBase> _party = new List<UnitBase>();
        private int _currentWaitTime;

        public string Name { get => _name; set => _name = value; }
        public Sprite Icon { get => _icon; set => _icon = value; }
        public bool Busy { get => _busy; set => _busy = value; }
        public bool Visible { get => _visible; set => _visible = value; }
        public int KdTime { get => _kDTime; set => _kDTime = value; }
        public int CurrentKDTime { get => _currentKDTime; set => _currentKDTime = value; }
        public List<LutInfo> LutInfo { get => _lutInfo; set => _lutInfo = value; }
        public List<UnitBase> Party { get => _party; set => _party = value; }
        public int CurrentWaitTime { get => _currentWaitTime; set => _currentWaitTime = value; }

        public Dungeon(Sprite icon, string name, int kDTime, List<LutInfo> lutInfo)
        {
            _icon = icon;
            _name = name;
            _kDTime = kDTime;
            _lutInfo = lutInfo;
        }

        public void StartQuest()
        {
            GameDataContainer.Instance.GetGameData.OnDayPassed += OnDayPassedAction;
            _currentKDTime = KdTime;
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