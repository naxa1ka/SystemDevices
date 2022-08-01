namespace Source.Tests
{
    public class DummyDeviceView : IDeviceView
    {
        public IView<UnityEngine.Vector3> Position { get; }
    }
}