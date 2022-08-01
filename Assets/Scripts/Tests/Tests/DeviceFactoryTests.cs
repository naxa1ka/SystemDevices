﻿using NUnit.Framework;

namespace Source.Tests
{
    public class DeviceFactoryTests
    {
        private StubSystemLoop _stubSystemLoop;
        private DeviceFactory _deviceFactory;

        [SetUp]
        public void Setup()
        {
            var viewFactory = new MockDeviceViewFactory(new DummyDeviceView());
            _stubSystemLoop = new StubSystemLoop();
            _deviceFactory = new DeviceFactory(viewFactory, _stubSystemLoop);
        }

        [Test]
        public void CreateAnalogDevice()
        {
            var device = _deviceFactory.CreateDevice(1, new Vector3());
            Assert.AreEqual(1, device.Id);
        }
        
        [Test]
        public void CreateDiscreteDevice()
        {
            var device = _deviceFactory.CreateDevice(2, new Vector3(), 10);
            Assert.AreEqual(2, device.Id);
        }
        
        [Test]
        public void CreateDiscreteDeviceWhichMustBeInUpdatableList()
        {
           _deviceFactory.CreateDevice(2, new Vector3(), 10);
           Assert.AreNotEqual(0,  _stubSystemLoop.Updatebles.Count);
        }
    }
}