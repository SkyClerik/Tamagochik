namespace Data.Dungeon
{
    using Data.Item;
    using Data.Units;
    using System.Collections.Generic;
    using UnityEngine;

    [System.Serializable]
    [CreateAssetMenu(fileName = "Dungeon", menuName = "Data/Dungeons/Dungeon")]
    public class Dungeon : ScriptableObject
    {
        [SerializeField]
        private string _name;
        [SerializeField]
        private Sprite _icon;
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

        public string Name { get => _name; set => _name = value; }
        public Sprite Icon { get => _icon; set => _icon = value; }
        public bool Busy { get => _busy; set => _busy = value; }
        public bool Visible { get => _visible; set => _visible = value; }
        public int StartKDTime { get => _startKDTime; set => _startKDTime = value; }
        public int CurrentKDTime { get => _currentKDTime; set => _currentKDTime = value; }
        public LutData GetLutData => _lutData;
        public List<UnitBase> Party { get => _party; set => _party = value; }
        public int CurrentWaitTime { get => _currentWaitTime; set => _currentWaitTime = value; }

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