using UnityEngine;
namespace Data.Rects
{
    [CreateAssetMenu(fileName = "RectsData", menuName = "Data/Rects")]
    public class RectsData : ScriptableObject, IInit
    {
        private Rect _leftArea;
        private Rect _rightArea;
        private Rect _buttonsArea;
        private Rect _kraftWindowArea;
        private Rect _upArea;
        private const int _buttonSizeWidth = 256;
        private const int _icoSize = 32;
        private const int _upHudHeight = 64;
        private GUILayoutOption[] _mainButtonsOption = new[] { GUILayout.Width(_buttonSizeWidth), GUILayout.Height(_icoSize) };

        public Rect LeftArea => _leftArea;
        public Rect RightArea => _rightArea;
        public Rect ButtonsArea => _buttonsArea;
        public Rect KraftWindowArea => _kraftWindowArea;
        public Rect UpArea => _upArea;
        public int GetButtonSizeWidth => _buttonSizeWidth;
        public int GetIcoSize => _icoSize;
        public GUILayoutOption[] MainButtonsOption => _mainButtonsOption;

        public void Init(params object[] list)
        {
            float screenW = Screen.width;
            float screenH = Screen.height;

            //-----
            float x = 0;
            float y = 0;
            float w = screenW;
            float h = _upHudHeight;
            _upArea = new Rect(x, y, w, h);

            //-----
            x = 0;
            y = _upHudHeight;
            w = _icoSize;
            h = screenH - _upHudHeight;
            _leftArea = new Rect(x, y, w, h);

            //-----
            x = LeftArea.width;
            y = _upHudHeight;
            w = _buttonSizeWidth + _icoSize;
            h = screenH - _upHudHeight;
            _buttonsArea = new Rect(x, y, w, h);

            //-----
            x = ButtonsArea.xMax;
            y = _upHudHeight;
            w = screenW - ButtonsArea.width - LeftArea.width;
            h = screenH - _upHudHeight;
            _kraftWindowArea = new Rect(x, y, w, h);

            //-----
            x = screenW - _buttonSizeWidth;
            y = _upArea.height;
            w = _buttonSizeWidth;
            h = screenH - _upArea.height;
            _rightArea = new Rect(x, y, w, h);
        }
    }
}