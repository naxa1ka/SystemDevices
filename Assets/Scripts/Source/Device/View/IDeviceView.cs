namespace Source
{
    public interface IDeviceView
    {
        public IView<Vector3> Position { get; }
        public IView<Vector3> Rotation { get; }
    }
}