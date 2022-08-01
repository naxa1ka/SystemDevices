using System;

namespace Source
{
    public class ExceptionCollisionResolver : ICollisionResolver
    {
        public void Resolve(IReadOnlyDevice device, Vector3 targetPosition)
        {
            throw new CollisionException($"Device is already busy with id: {device.Id}");
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