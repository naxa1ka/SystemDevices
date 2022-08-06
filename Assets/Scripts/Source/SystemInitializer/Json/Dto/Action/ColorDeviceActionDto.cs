using System;

namespace Source
{
    [Serializable]
    public class ColorDeviceActionDto : BaseDeviceActionDto
    {
        public SerializableColor InitColor;
        public SerializableColor TargetColor;
    }
}