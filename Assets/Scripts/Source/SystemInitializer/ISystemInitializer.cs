namespace Source
{
    public interface ISystemInitializer
    {
        void AddDevice(int id, Vector3 initPosition);
        void AddDevice(int id, Vector3 initPosition, float durationChangingPosition);
    }
}