using System;

namespace Source
{
    public class SystemDevicesWithCollisionResolver : ISystemDevices //попытка в декоратор вышло соу-соу
    {
        private readonly ISystemDevices _systemDevices;
        private readonly IReadOnlySystemDevices _readOnlySystemDevices;
        private readonly ICollisionResolver _collisionResolver;

        public SystemDevicesWithCollisionResolver(
            ISystemDevices systemDevices,
            IReadOnlySystemDevices readOnlySystemDevices,
            ICollisionResolver collisionResolver)
        {
            _systemDevices = systemDevices;
            _readOnlySystemDevices = readOnlySystemDevices;
            _collisionResolver = collisionResolver;
        }

        public void SetTargetDeviceState(int id, Vector3 targetPosition)
        {
            if (_readOnlySystemDevices.TryGetDevice(id, out var device))
            {
                if (device.IsBusy)
                    _collisionResolver.Resolve(device, targetPosition);
                else
                    _systemDevices.SetTargetDeviceState(id, targetPosition);
            }
            else
            {
                throw new ArgumentException($"Device doesn`t exist with same id {id}!");
            }
        }
    }
}