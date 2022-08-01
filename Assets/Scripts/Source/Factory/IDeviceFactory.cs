namespace Source
{
    public interface IDeviceFactory
    {
        Device CreateDevice(int id, Vector3 initPosition);
        Device CreateDevice(int id, Vector3 initPosition, float durationChangingState);
    }
}