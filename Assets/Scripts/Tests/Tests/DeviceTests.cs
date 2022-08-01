using System;
using NUnit.Framework;

namespace Source.Tests
{
    public class DeviceTests
    {
        [Test]
        public void IsTargetStateDiscreteDeviceChanging()
        {
            var device = new DiscreteDevice(1, new Vector3(0, 0, 0));
            var targetPosition = new Vector3(1, 1, 1);
            device.SetTargetPosition(targetPosition);
            Assert.AreEqual(targetPosition, device.Position);
        }

        [Test]
        public void IsDurationChangingStateAnalogDeviceCannotBeLessZero()
        {
            Assert.Throws<ArgumentException>(() => new AnalogDevice(1, new Vector3(), -10));
        }

        [Test]
        public void IsAnalogDeviceChangingBusyState()
        {
            var systemLoop = new MockSystemLoop();
            var device = new AnalogDevice(1, new Vector3(), 1);
            systemLoop.Attach(device);
            
            device.SetTargetPosition(new Vector3(1, 1, 1));
            systemLoop.Update(0.9f);
            Assert.AreEqual(true, device.IsBusy);
            
            systemLoop.Update(0.11f);
            Assert.AreEqual(false, device.IsBusy);
        }

        [Test]
        public void IsAnalogDeviceThrowEventAfterEndChangingState()
        {
            var systemLoop = new MockSystemLoop();
            var device = new AnalogDevice(1, new Vector3(), 1);
            systemLoop.Attach(device);

            var counter = 0;
            device.TaskCompleted += () => counter++;

            device.SetTargetPosition(new Vector3(1, 1, 1));
            systemLoop.Update(1.1f);
            
            Assert.AreEqual(1, counter);
        }
        
        [Test]
        public void IsAnalogDeviceSmoothChangingState()
        {
            var systemLoop = new MockSystemLoop();
            var device = new AnalogDevice(1, new Vector3(), 10);
            systemLoop.Attach(device);
            
            device.SetTargetPosition(new Vector3(1, 1, 1));
            systemLoop.Update(9f);
            
            var smoothState = Vector3.Lerp(new Vector3(), new Vector3(1,1,1), 9f / 10f);
            Assert.AreEqual(smoothState, device.Position);
        }
    }
}