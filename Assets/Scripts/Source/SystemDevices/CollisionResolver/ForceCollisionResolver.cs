namespace Source
{
    public class ForceCollisionResolver : ICollisionResolver
    {
        private readonly ICommandAfterResolve _commandAfterResolve;

        public ForceCollisionResolver(ICommandAfterResolve commandAfterResolve)
        {
            _commandAfterResolve = commandAfterResolve;
        }

        public void Resolve(IReadOnlyDevice device, Vector3 targetPosition)
        {
            _commandAfterResolve.Execute(new CommandAfterResolveCtx(device.Id, targetPosition));
        }
    }
}