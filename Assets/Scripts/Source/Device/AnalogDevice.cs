using System;

namespace Source
{
    public sealed class AnalogDevice : Device, IUpdateble
    {
        private readonly float _durationChangingPosition;
        private float _currentTimeAfterStartChangingState;
        private Vector3 _targetPosition;
        private Vector3 _positionBeforeInitNew;

        public AnalogDevice(int id, Vector3 position, float durationChangingPosition)
            : base(id, position)
        {
            if (durationChangingPosition < 0)
                throw new ArgumentException("Duration changing must be greater zero!");

            _durationChangingPosition = durationChangingPosition;
        }

        public override void SetTargetPosition(Vector3 targetPosition)
        {
            _currentTimeAfterStartChangingState = 0;
            _positionBeforeInitNew = Position;
            _targetPosition = targetPosition;
            IsBusy = true;
        }

        public void Update(float dt)
        {
            if (!IsBusy) return;

            _currentTimeAfterStartChangingState += dt;
            UpdateState();
        }

        private void UpdateState()
        {
            Position = Vector3.Lerp(_positionBeforeInitNew, _targetPosition,
                _currentTimeAfterStartChangingState / _durationChangingPosition);

            if (_currentTimeAfterStartChangingState - _durationChangingPosition >= 0)
            {
               OnComplete();
            }
        }
    }
}