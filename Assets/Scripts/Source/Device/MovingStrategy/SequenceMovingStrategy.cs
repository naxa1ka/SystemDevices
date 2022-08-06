using System;
using System.Collections.Generic;

namespace Source
{
    public class SequenceMovingStrategy : IMovingStrategy
    {
        private readonly IMovingStrategy _movingStrategy;
        private readonly List<MovingAction> _movingActions;
        private float _currentTime;
        
        public bool IsBusy => _movingStrategy.IsBusy;
        public event Action TaskCompleted;

        public SequenceMovingStrategy(IMovingStrategy movingStrategy, List<MovingAction> movingActions)
        {
            _movingStrategy = movingStrategy;
            _movingActions = movingActions;
        }

        public void Update(float dt)
        {
            if (!IsBusy) return;

            _currentTime += dt;
            _movingStrategy.Update(dt);

            foreach (var action in _movingActions)
            {
                if (IsTimeToExecuteAction(action))
                    action.IMovingAction.Update(dt);
            }
        }

        private bool IsTimeToExecuteAction(MovingAction action)
        {
            if (_currentTime > action.StartTime && action.IsInfinityAction)
                return true;
            return _currentTime > action.StartTime && _currentTime < action.StartTime + action.Duration;
        }
        
        public void SetTargetPosition(Vector3 targetPosition)
        {
            Reset();
            _movingStrategy.SetTargetPosition(targetPosition);
            _movingStrategy.TaskCompleted += OnComplete;
        }

        private void Reset()
        {
            foreach (var action in _movingActions)
                action.IMovingAction.Reset();
            _currentTime = 0;
        }

        private void OnComplete()
        {
            _movingStrategy.TaskCompleted -= OnComplete;
            TaskCompleted?.Invoke();
        }
    }
}