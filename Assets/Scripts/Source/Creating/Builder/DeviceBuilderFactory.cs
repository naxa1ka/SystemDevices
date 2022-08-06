namespace Source
{
    public class DeviceBuilderFactory
    {
        private readonly IDeviceViewFactory _deviceViewFactory;
        private readonly ISystemLoop _systemLoop;

        public DeviceBuilderFactory(
            IDeviceViewFactory deviceViewFactory,
            ISystemLoop systemLoop)
        {
            _deviceViewFactory = deviceViewFactory;
            _systemLoop = systemLoop;
        }

        public IDeviceBuilder Create() => new DeviceBuilder(_deviceViewFactory, _systemLoop);
    }
}