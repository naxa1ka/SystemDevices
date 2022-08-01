using System;

namespace Source
{
    [Serializable]
    public class AnalogDeviceDto : BaseDto
    {
        public int Id;
        public Vector3 Position;
        public float DurationChange;
    }
}