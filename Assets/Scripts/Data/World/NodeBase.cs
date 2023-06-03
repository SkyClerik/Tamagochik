using UnityEngine;

namespace Data.World
{
    public class NodeBase : ScriptableObject
    {
        [SerializeField]
        private string _title;
        [SerializeField]
        private string _buttonText;
        [SerializeField]
        private Sprite _icon;

        public string GetTitle => _title;
        public string ButtonText => _buttonText;
        public Sprite Icon => _icon;
    }
}