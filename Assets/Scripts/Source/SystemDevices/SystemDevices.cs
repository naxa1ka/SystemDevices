using System;
using System.Collections.Generic;
using System.Linq;

namespace Source
{
    public sealed class SystemDevices : IMutableSystemDevices, ISystemDevices, IReadOnlySystemDevices
    {
        public List<int> ListId => _devices.Keys.ToList();
        private readonly Dictionary<int, Device> _devices;

        public SystemDevices()
        {
            _devices = new Dictionary<int, Device>();
        }

        public void AddDevice(Device device)
        {
            if (_devices.ContainsKey(device.Id))
                throw new ArgumentException($"Device is already contains with same id {device.Id}!");

            _devices.Add(device.Id, device);
        }

        public void SetTargetDeviceState(int id, Vector3 targetPosition)
        {
            if (!_devices.ContainsKey(id))
                throw new ArgumentException($"Device doesn`t exist with same id {id}!");

            _devices[id].SetTargetPosition(targetPosition);
        }
    }
}