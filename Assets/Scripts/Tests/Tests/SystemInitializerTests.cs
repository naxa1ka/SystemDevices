// using NUnit.Framework;
//
// namespace Source.Tests
// {
//     public class SystemInitializerTests
//     {
//         private SystemInitializer _systemInitializer;
//         private StubSystemDevices _systemDevices;
//
//         [SetUp]
//         public void Setup()
//         {
//             var viewFactory = new MockDeviceViewFactory(new DummyDeviceView());
//             _systemDevices = new StubSystemDevices();
//             var deviceFactory = new DeviceBuilder(viewFactory, new DummySystemLoop());
//             _systemInitializer = new SystemInitializer(_systemDevices, deviceFactory);
//         }
//
//         [Test]
//         public void AddAnalogDevice()
//         {
//             _systemInitializer.AddDevice(1, new Vector3(), 10);
//             Assert.AreEqual(_systemDevices.Device.Id, 1);
//         }
//         
//         [Test]
//         public void AddDiscreteDevice()
//         {
//             _systemInitializer.AddDevice(2, new Vector3());
//             Assert.AreEqual(_systemDevices.Device.Id, 2);
//         }
//     }
// }