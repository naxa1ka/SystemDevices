using System;

namespace Source
{
    public sealed class AnalogMovingStrategy : IMovingStrategy
    {
        public bool IsBusy { private set; get; }
        public event Action TaskCompleted;

        private readonly IView<Vector3> _view;
        private readonly float _durationChangingPosition;
        private float _currentTimeAfterStartChangingState;
        private Vector3 _targetPosition;
        private Vector3 _positionBeforeInitNew;
        
        private Vector3 _position;

        public AnalogMovingStrategy(IView<Vector3> view, Vector3 position, float durationChangingPosition)
        {
            if (durationChangingPosition < 0)
                throw new ArgumentException("Duration changing must be greater zero!");

            _position = position;
            _view = view;
            _durationChangingPosition = durationChangingPosition;
        }

        public void SetTargetPosition(Vector3 targetPosition)
        {
            _currentTimeAfterStartChangingState = 0;
            _positionBeforeInitNew = _position;
            _targetPosition = targetPosition;
            IsBusy = true;
        }

        public void Update(float dt)
        {
            if (!IsBusy) return;

            _currentTimeAfterStartChangingState += dt;
            UpdateState();
            
            _view.SetValue(_position);
        }

        private void UpdateState()
        {
            _position = Vector3.Lerp(_positionBeforeInitNew, _targetPosition,
                _currentTimeAfterStartChangingState / _durationChangingPosition);

            if (_currentTimeAfterStartChangingState - _durationChangingPosition >= 0)
                OnComplete();
        }

        private void OnComplete()
        {
            IsBusy = false;
            TaskCompleted?.Invoke();
        }
    }
}