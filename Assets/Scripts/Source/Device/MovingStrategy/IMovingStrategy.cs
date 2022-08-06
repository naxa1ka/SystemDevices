namespace Source
{
    public interface IMovingStrategy : IAwaitableStrategy, IUpdateble
    {
        public void SetTargetPosition(Vector3 targetPosition);
    }
}