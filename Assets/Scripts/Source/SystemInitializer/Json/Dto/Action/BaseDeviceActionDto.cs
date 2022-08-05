using System;

namespace Source
{
    [Serializable]
    public class BaseDeviceActionDto
    {
        public DeviceActionDtoType Type;
    }
    
    public enum DeviceActionDtoType
    {
        None = 0,
        Rotation = 1,
    }
}