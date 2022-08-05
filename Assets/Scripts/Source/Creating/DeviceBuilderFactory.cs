namespace Source
{
    public class DeviceBuilderFactory
    {
        private readonly IDeviceViewFactory _deviceViewFactory;
        private readonly ISystemLoop _systemLoop;
        private readonly ICommandAfterResolve _commandAfterResolve;

        public DeviceBuilderFactory(
            IDeviceViewFactory deviceViewFactory,
            ISystemLoop systemLoop,
            ICommandAfterResolve commandAfterResolve)
        {
            _deviceViewFactory = deviceViewFactory;
            _systemLoop = systemLoop;
            _commandAfterResolve = commandAfterResolve;
        }

        public IDeviceBuilder Create() => new DeviceBuilder(_deviceViewFactory, _systemLoop, _commandAfterResolve);
    }
}