namespace Source.Tests
{
    public class StubSystemDevices : IMutableSystemDevices
    {
        public Device Device;
        
        public void AddDevice(Device device)
        {
            Device = device;
        }
    }
}