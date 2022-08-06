using UnityEngine;

namespace Source
{
    public class DeviceColorChanger : IOnMovingAction
    {
        private readonly IView<Color32> _view;
        private readonly Color32 _initColor;
        private readonly Color32 _targetColor;

        private readonly float _duration;
        private float _currentTime;
        private Color32 _color;

        public DeviceColorChanger(IView<Color32> view, Color initColor, Color targetColor, float duration)
        {
            _view = view;
            _initColor = initColor;
            _targetColor = targetColor;
            _duration = duration;
        }
        
        public void Update(float dt)
        {
            _currentTime += dt;
            _color = Color32.Lerp(_initColor, _targetColor, _currentTime / _duration);
            _view.SetValue(_color);
        }

        public void Reset()
        {
            _currentTime = 0;
            _color = _initColor;
        }
    }
}