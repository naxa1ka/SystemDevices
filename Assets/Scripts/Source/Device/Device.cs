using System.Collections.Generic;

namespace Source
{
    public class Device : IUpdateble
    {
        private readonly ICollisionResolver _collisionResolver;
        private readonly IMovingStrategy _movingStrategy;
        private readonly List<IOnMovingAction> _onMovingStrategies;
        
        public int Id { get; }
        
        public Device(
            ICollisionResolver collisionResolver,
            IMovingStrategy movingStrategy,
            List<IOnMovingAction> onMovingStrategies,
            int id)
        {
            _collisionResolver = collisionResolver;
            _movingStrategy = movingStrategy;
            _onMovingStrategies = onMovingStrategies;
            Id = id;
        }

        public void SetTargetPosition(Vector3 targetPosition)
        {
            if (_movingStrategy.IsBusy)
                _collisionResolver.Resolve(Id, targetPosition, () => { SetTargetPosition2(targetPosition);});
            else
                _movingStrategy.SetTargetPosition(targetPosition);
        }

        private void SetTargetPosition2(Vector3 targetPosition)
        {
                _movingStrategy.SetTargetPosition(targetPosition);
        }
        
        public void Update(float dt)
        {
            _movingStrategy.Update(dt);
            if (!_movingStrategy.IsBusy) return;
            
            foreach (var onMovingStrategy in _onMovingStrategies)
                onMovingStrategy.Update(dt);
        }
    }
}