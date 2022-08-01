namespace Source
{
    public sealed class SystemInitializer : ISystemInitializer
    {
        private readonly IMutableSystemDevices _mutableSystemDevices;
        private readonly IDeviceFactory _deviceFactory;

        public SystemInitializer(IMutableSystemDevices mutableSystemDevices, IDeviceFactory deviceFactory)
        {
            _mutableSystemDevices = mutableSystemDevices;
            _deviceFactory = deviceFactory;
        }

        public void AddDevice(int id, Vector3 initPosition)
        {
            var device = _deviceFactory.CreateDevice(id, initPosition);
            AddDevice(device);
        }

        public void AddDevice(int id, Vector3 initPosition, float durationChangingPosition)
        {
            var device = _deviceFactory.CreateDevice(id, initPosition, durationChangingPosition);
            AddDevice(device);
        }

        private void AddDevice(Device device) => _mutableSystemDevices.AddDevice(device);
    }
}