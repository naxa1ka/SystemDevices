namespace Source
{
    public class CommandAfterResolve : ICommandAfterResolve
    {
        private readonly ISystemDevices _systemDevices;

        public CommandAfterResolve(ISystemDevices systemDevices)
        {
            _systemDevices = systemDevices;
        }
        
        public void Execute(CommandAfterResolveCtx ctx) 
        {
            _systemDevices.SetTargetDeviceState(ctx.DeviceId, ctx.TargetState);
        }
    }
}