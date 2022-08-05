using System;

namespace Source
{
    public class ForceCollisionResolver : ICollisionResolver
    {
        public void Resolve(int deviceId, Vector3 targetPosition, Action onResolved)
        {
            onResolved.Invoke();
        }
        
    }
}