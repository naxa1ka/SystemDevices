namespace Source
{
    public class DeviceRotator : IMovingAction
    {
        private readonly IView<Vector3> _view;
        private readonly Vector3 _rotationSpeed;
        
        private Vector3 _angle;
        
        public DeviceRotator(IView<Vector3> view, Vector3 rotationSpeed)
        {
            _view = view;
            _rotationSpeed = rotationSpeed;
        }

        public void Update(float dt)
        {
            _angle += _rotationSpeed;
            _view.SetValue(_angle);
        }

        public void Reset()
        {
            
        }
    }
}