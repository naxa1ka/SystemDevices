namespace Source
{
    public interface IInput
    {
        public UnityEngine.Vector3 MousePosition { get; }
        public bool WasPKMClicked { get; }
    }
}