using UnityEngine;

namespace Source
{
    public class DeviceInteractorPresenter : IUpdateble
    {
        private readonly IDeviceInteractorView _view;
        private readonly IReadOnlySystemDevices _readOnlySystemDevices;
        private readonly ISystemDevices _systemDevices;
        private readonly Camera _camera;
        private readonly IInput _input;

        public DeviceInteractorPresenter(
            IReadOnlySystemDevices readOnlySystemDevices,
            ISystemDevices systemDevices,
            IInput input,
            Camera camera,
            IDeviceInteractorView view)
        {
            _readOnlySystemDevices = readOnlySystemDevices;
            _systemDevices = systemDevices;
            _input = input;
            _camera = camera;
            _view = view;
        }

        public void Update(float dt)
        {
            if (_input.WasLKMClicked)
            {
                var worldPosition = GetWorldPositionOfMouse();

                var selectedId = _readOnlySystemDevices.ListId[_view.SelectedIndex.Value];
                _systemDevices.SetTargetDeviceState(selectedId, worldPosition.FromMonoVector3());
            }

            _view.ListIdDevices.SetValue(_readOnlySystemDevices.ListId);
        }

        private UnityEngine.Vector3 GetWorldPositionOfMouse()
        {
            var mousePosition = _input.MousePosition;
            const int distanceOfCameraPlane = 10;
            mousePosition.z = distanceOfCameraPlane;
            var worldPosition = _camera.ScreenToWorldPoint(mousePosition);
            return worldPosition;
        }
    }
}