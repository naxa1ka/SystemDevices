using NUnit.Framework;

namespace Source.Tests
{
    public class CollisionResolverTests
    {
        private CommonSystemDevices _commonSystemDevices;

        [SetUp]
        public void Setup()
        {
            _commonSystemDevices = new CommonSystemDevices();
        }

        [Test]
        public void ThrowExceptionWhenDeviceBusy()
        {
            var exceptionResolver = new ExceptionCollisionResolver();
            var system = new SystemDevicesWithCollisionResolver(_commonSystemDevices, _commonSystemDevices, exceptionResolver);
            
            _commonSystemDevices.AddDevice(new AnalogDevice(1, new Vector3(), 10));
            
            var targetPosition = new Vector3(1, 1, 1);
            system.SetTargetDeviceState(1, targetPosition);
            Assert.Throws<CollisionException>(() => system.SetTargetDeviceState(1, targetPosition));
        }

        [Test]
        public void ForceChangingPositionWhenDeviceBusy()
        {
            MockSystemLoop systemLoop = new MockSystemLoop();
            var forceCollisionResolver = new ForceCollisionResolver(new CommandAfterResolve(_commonSystemDevices));
            var system = new SystemDevicesWithCollisionResolver(
                _commonSystemDevices,
                _commonSystemDevices,
                forceCollisionResolver
            );

            var device = new AnalogDevice(1, new Vector3(), 10);
            systemLoop.Attach(device);
            _commonSystemDevices.AddDevice(device);
            
            system.SetTargetDeviceState(1, new Vector3(1, 1, 1));
            device.Update(1f);
            
            var targetState = new Vector3(2, 2, 2);
            system.SetTargetDeviceState(1, targetState);
            device.Update(10f);
            
            Assert.AreEqual(targetState, device.Position);
        }

        [Test]
        public void AwaitChangingPositionWhenDeviceBusy()
        {
            MockSystemLoop systemLoop = new MockSystemLoop();
            var forceCollisionResolver = new AwaitableCollisionResolver(new CommandAfterResolve(_commonSystemDevices));
            var system = new SystemDevicesWithCollisionResolver(
                _commonSystemDevices,
                _commonSystemDevices,
                forceCollisionResolver
            );
            var device = new AnalogDevice(1, new Vector3(), 10);
            systemLoop.Attach(device);
            _commonSystemDevices.AddDevice(device);

            var firstTargetState = new Vector3(1, 1, 1);
            system.SetTargetDeviceState(1, firstTargetState);
            device.Update(10f);
            Assert.AreEqual(firstTargetState, device.Position);

            var secondTargetState = new Vector3(2, 2, 2);
            system.SetTargetDeviceState(1, secondTargetState);
            device.Update(10f);
            Assert.AreEqual(secondTargetState, device.Position);
        }
    }
}