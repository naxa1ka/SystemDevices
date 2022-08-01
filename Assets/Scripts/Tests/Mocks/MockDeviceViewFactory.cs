namespace Source.Tests
{
    public class MockDeviceViewFactory : IDeviceViewFactory
    {
        private readonly IDeviceView _deviceView;

        public MockDeviceViewFactory(IDeviceView deviceView)
        {
            _deviceView = deviceView;
        }
        
        public IDeviceView Create()
        {
            return _deviceView;
        }
    }
}