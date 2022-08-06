namespace Source
{
    public sealed class QueueAwaitableCollisionResolver : ICollisionResolver
    {
        public async void Resolve(Device device, Vector3 targetPosition)
        {
            await device.MovingStrategy.Await();
            device.SetTargetPosition(targetPosition);
        }
    }
}