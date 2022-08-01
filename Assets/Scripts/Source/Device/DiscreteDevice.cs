namespace Source
{
    public sealed class DiscreteDevice : Device
    {
        public DiscreteDevice(int id, Vector3 position) : base(id, position)
        {
        }

        public override void SetTargetPosition(Vector3 targetPosition)
        {
            Position = targetPosition;
            OnComplete();
        }
    }
}