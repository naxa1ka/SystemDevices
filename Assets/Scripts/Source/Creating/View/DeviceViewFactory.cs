using UnityEngine;

namespace Source
{
    public class DeviceViewFactory : IDeviceViewFactory
    {
        private readonly DeviceView _prefab;

        public DeviceViewFactory(DeviceView prefab)
        {
            _prefab = prefab;
        }

        public IDeviceView Create()
        {
            return Object.Instantiate(_prefab);
        }
    }
}