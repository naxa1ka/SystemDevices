using System;

namespace Source
{
    [Serializable]
    public class RotationDeviceActionDto : BaseDeviceActionDto
    {
        public Vector3 RotationSpeed;
    }
}