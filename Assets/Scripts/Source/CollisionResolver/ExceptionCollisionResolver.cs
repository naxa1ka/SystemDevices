using System;

namespace Source
{
    public class ExceptionCollisionResolver : ICollisionResolver
    {
        public void Resolve(Device device, Vector3 targetPosition)
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