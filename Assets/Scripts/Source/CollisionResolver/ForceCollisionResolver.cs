namespace Source
{
    public class ForceCollisionResolver : ICollisionResolver
    {
        public void Resolve(Device device, Vector3 targetPosition)
        {
            device.MovingStrategy.SetTargetPosition(targetPosition);
        }
    }
}