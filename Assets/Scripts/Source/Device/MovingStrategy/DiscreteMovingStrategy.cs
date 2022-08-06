using System;

namespace Source
{
    public class DiscreteMovingStrategy : IMovingStrategy
    {
        public bool IsBusy => false;
        public event Action TaskCompleted;

        private Vector3 _position;
        private readonly IView<Vector3> _view;

        public DiscreteMovingStrategy(IView<Vector3> view, Vector3 position)
        {
            _view = view;
            _position = position;
        }

        public void Update(float dt)
        {
            _view.SetValue(_position);
        }

        public void SetTargetPosition(Vector3 targetPosition)
        {
            _position = targetPosition;
        }
    }
}