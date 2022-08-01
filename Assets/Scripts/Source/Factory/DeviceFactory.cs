namespace Source
{
    public class DeviceFactory : IDeviceFactory
    {
        private readonly IDeviceViewFactory _deviceViewFactory;
        private readonly ISystemLoop _systemLoop;

        public DeviceFactory(IDeviceViewFactory deviceViewFactory, ISystemLoop systemLoop)
        {
            _deviceViewFactory = deviceViewFactory;
            _systemLoop = systemLoop;
        }

        public Device CreateDevice(int id, Vector3 initPosition)
        {
            var device = new DiscreteDevice(id, initPosition);
            BindDevice(device);
            return device;
        }

        public Device CreateDevice(int id, Vector3 initPosition, float durationChangingState)
        {
            var device = new AnalogDevice(id, initPosition, durationChangingState);
            _systemLoop.Attach(device);
            BindDevice(device);
            return device;
        }

        private void BindDevice(IReadOnlyDevice device)
        {
            var view = _deviceViewFactory.Create();
            var presenter = new DevicePresenter(view, device);
            _systemLoop.Attach(presenter);
        }
    }
}