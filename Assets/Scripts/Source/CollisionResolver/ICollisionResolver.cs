namespace Source
{
    public interface ICollisionResolver
    {
        void Resolve(Device device, Vector3 targetPosition);
    }
}