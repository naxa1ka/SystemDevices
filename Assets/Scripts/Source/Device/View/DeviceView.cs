using UnityEngine;

namespace Source
{
    public class DeviceView : MonoBehaviour, IDeviceView
    {
        [SerializeField] private PositionView _positionView;
        [SerializeField] private RotationView _rotationView;

        public IView<Vector3> Position => _positionView;
        public IView<Vector3> Rotation => _rotationView;
    }
}