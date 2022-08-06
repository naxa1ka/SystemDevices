using UnityEngine;

namespace Source
{
    public interface IDeviceView
    {
        public IView<Vector3> Position { get; }
        public IView<Vector3> Rotation { get; }
        public IView<Color32> Color { get; }
    }
}