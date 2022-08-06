using System;

namespace Source
{
    [Serializable]
    public class BaseDeviceActionDto
    {
        public DeviceActionDtoType Type;
        public float StartTime;
        public float Duration;
    }
    
    public enum DeviceActionDtoType
    {
        None = 0,
        Rotation = 1,
        Color = 2
    }
}