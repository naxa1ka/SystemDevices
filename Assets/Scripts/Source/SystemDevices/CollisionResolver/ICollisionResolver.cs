namespace Source
{
    public interface ICollisionResolver
    {
        void Resolve(IReadOnlyDevice device, Vector3 targetPosition);
    }
}