namespace Source
{
    public class DeviceRotator : IOnMovingAction
    {
        private readonly Vector3 _rotationSpeed;
        public Vector3 Angle { get; private set; }
        
        public DeviceRotator(Vector3 rotationSpeed)
        {
            _rotationSpeed = rotationSpeed;
        }

        public void Update(float dt)
        {
            Angle += _rotationSpeed;
        }
    }
}