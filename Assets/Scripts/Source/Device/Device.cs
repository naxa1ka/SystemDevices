namespace Source
{
    public class Device : IUpdateble
    {
        private readonly ICollisionResolver _collisionResolver;

        public IMovingStrategy MovingStrategy { get; }
        public int Id { get; }

        public Device(
            ICollisionResolver collisionResolver,
            IMovingStrategy movingStrategy,
            int id)
        {
            _collisionResolver = collisionResolver;
            MovingStrategy = movingStrategy;
            Id = id;
        }

        public void SetTargetPosition(Vector3 targetPosition)
        {
            if (MovingStrategy.IsBusy)
                _collisionResolver.Resolve(this, targetPosition);
            else
                MovingStrategy.SetTargetPosition(targetPosition);
        }

        public void Update(float dt)
        {
            MovingStrategy.Update(dt);
        }
    }
}