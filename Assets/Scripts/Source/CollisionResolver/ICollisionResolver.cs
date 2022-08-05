using System;

namespace Source
{
    public interface ICollisionResolver
    {
        void Resolve(int deviceId, Vector3 targetPosition, Action onResolved);
    }
}