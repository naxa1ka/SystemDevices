using UnityEngine;

namespace Source
{
    public class DeviceView : MonoBehaviour, IDeviceView
    {
        [SerializeField] private PositionView _positionView;
        public IView<UnityEngine.Vector3> Position => _positionView;
    }
}