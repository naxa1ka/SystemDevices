using System;

namespace Source
{
    public class MenuSystemInitializerPresenter : IDisposable
    {
        private readonly IMenuSystemInitializerView _view;
        private readonly ISystemInitializer _systemInitializer;
        private readonly IReadOnlySystemDevices _systemDevices;

        public MenuSystemInitializerPresenter(IMenuSystemInitializerView view,
            ISystemInitializer systemInitializer,
            IReadOnlySystemDevices systemDevices)
        {
            _view = view;
            _systemInitializer = systemInitializer;
            _systemDevices = systemDevices;

            _view.SpawnAnalogDeviceTrigger.Clicked += OnSpawnAnalogDeviceClicked;
            _view.SpawnDiscreteDeviceTrigger.Clicked += OnSpawnDiscreteDeviceClicked;
        }

        private void OnSpawnDiscreteDeviceClicked()
        {
            if (TryParseNotExistedId(out var id))
            {
                _systemInitializer.AddDevice(id, new Vector3());
            }
        }

        private void OnSpawnAnalogDeviceClicked()
        {
            if (float.TryParse(_view.DurationChangingStateInput.Value, out var durationChangingState))
            {
                if (TryParseNotExistedId(out var id))
                {
                    _systemInitializer.AddDevice(id, new Vector3(), durationChangingState);
                }
            }
        }

        public void Dispose()
        {
            _view.SpawnAnalogDeviceTrigger.Clicked -= OnSpawnAnalogDeviceClicked;
            _view.SpawnDiscreteDeviceTrigger.Clicked -= OnSpawnDiscreteDeviceClicked;
        }

        private bool TryParseNotExistedId(out int result)
        {
            if (int.TryParse(_view.Id.Value, out var id))
            {
                if (!_systemDevices.TryGetDevice(id, out var device))
                {
                    result = id;
                    return true;
                }
            }

            result = default;
            return false;
        }
    }
}