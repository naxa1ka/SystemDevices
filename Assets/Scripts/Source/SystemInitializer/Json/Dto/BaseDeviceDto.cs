using System;
using System.Collections.Generic;

namespace Source
{
    [Serializable]
    public class BaseDeviceDto
    {
        public int Id;
        public Vector3 Position;
        public DeviceDtoType Type;
        public CollisionResolverType ResolverType;
        
        public List<object> DeviceActions;
    }

    public enum DeviceDtoType
    {
        None = 0,
        DiscreteDevice = 1,
        AnalogDevice = 2
    }
}