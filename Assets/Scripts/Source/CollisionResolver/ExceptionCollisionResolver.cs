using System;

namespace Source
{
    public class ExceptionCollisionResolver : ICollisionResolver
    {
        public void Resolve(int deviceId, Vector3 targetPosition, Action onResolved)
        {
            throw new CollisionException("Device is already busy!");
        }
    }

    public class CollisionException : Exception
    {
        public override string Message { get; }

        public CollisionException(string message)
        {
            Message = message;
        }
    }
}