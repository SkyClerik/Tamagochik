using UnityEngine;

namespace Data.World
{
    public class NodeBase : ScriptableObject
    {
        [SerializeField]
        private string _buttonText;
        [SerializeField]
        private Sprite _icon;

        public string ButtonText => _buttonText;
        public Sprite Icon => _icon;
    }
}