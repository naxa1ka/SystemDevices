namespace Source
{
    public sealed class AwaitableCollisionResolver : ICollisionResolver
    {
        public async void Resolve(Device device, Vector3 targetPosition)
        {
            await device.MovingStrategy.Await();
            device.MovingStrategy.SetTargetPosition(targetPosition);
        }
    }
}