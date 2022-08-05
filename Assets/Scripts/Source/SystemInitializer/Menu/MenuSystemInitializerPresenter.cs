using System;
using System.Linq;

namespace Source
{
    public class MenuSystemInitializerPresenter : IDisposable
    {
        private readonly IMenuSystemInitializerView _view;
        private readonly IReadOnlySystemDevices _systemDevices;
        private readonly DeviceBuilderFactory _deviceBuilderFactory;
        private readonly IMutableSystemDevices _mutableSystemDevices;

        public MenuSystemInitializerPresenter(
            IMenuSystemInitializerView view,
            IReadOnlySystemDevices systemDevices,
            DeviceBuilderFactory deviceBuilderFactory,
            IMutableSystemDevices mutableSystemDevices)
        {
            _view = view;
            _systemDevices = systemDevices;
            _deviceBuilderFactory = deviceBuilderFactory;
            _mutableSystemDevices = mutableSystemDevices;

            _view.SpawnDeviceTrigger.Clicked += OnSpawnButtonClicked;
            InitCollisionResolverTypeDropdown();
        }

        private void InitCollisionResolverTypeDropdown()
        {
            var listEnum = EnumExtensions.GetListEnum<CollisionResolverType>();
            listEnum.Remove(CollisionResolverType.None);
            _view.CollisionResolverType.SetValue(listEnum);
        }

        private void OnSpawnButtonClicked()
        {
            if (!TryParseNotExistedId(out var id)) return;
            
            var deviceBuilder = _deviceBuilderFactory.Create();
            if (float.TryParse(_view.DurationChangingStateInput.Value, out var duration))
            {
                deviceBuilder.SetMoveStrategy(new AnalogDeviceDto()
                {
                    Id = id,
                    DurationChange = duration,
                });
            }
            else
            {
                deviceBuilder.SetMoveStrategy(new DiscreteDeviceDto()
                {
                    Id = id,
                });
            }

            if (float.TryParse(_view.RotationAngleInput.Value, out var rotationAngle))
            {
                deviceBuilder.AddRotationToDevice(new RotationDeviceActionDto()
                {
                    RotationSpeed = new Vector3(rotationAngle, rotationAngle, rotationAngle)
                });
            }

            deviceBuilder.SetCollisionResolverType(_view.CollisionResolverType.Value);
            _mutableSystemDevices.AddDevice(deviceBuilder.Build());
        }

        private bool TryParseNotExistedId(out int result)
        {
            if (int.TryParse(_view.IdInput.Value, out var id))
            {
                if (!_systemDevices.ListId.Contains(id))
                {
                    result = id;
                    return true;
                }
            }

            throw new ArgumentException("Device with same id is exists!");
        }

        public void Dispose()
        {
            _view.SpawnDeviceTrigger.Clicked -= OnSpawnButtonClicked;
        }
    }
}