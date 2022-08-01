namespace Source
{
    public class DevicePresenter : IUpdateble
    {
        private readonly IDeviceView _deviceView;
        private readonly IReadOnlyDevice _device;

        public DevicePresenter(IDeviceView deviceView, IReadOnlyDevice device)
        {
            _deviceView = deviceView;
            _device = device;
        }

        public void Update(float dt)
        {
            _deviceView.Position.SetValue(_device.Position.ToMonoVector3());
        }
    }
}