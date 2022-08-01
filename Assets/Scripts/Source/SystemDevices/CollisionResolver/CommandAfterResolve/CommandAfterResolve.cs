namespace Source
{
    public class CommandAfterResolve : ICommandAfterResolve
    {
        private readonly ISystemDevices _systemDevices;

        public CommandAfterResolve(ISystemDevices systemDevices)
        {
            _systemDevices = systemDevices;
        }

        //руки тянулись сделать эту команду ибо в моей голове resolve`ру должно быть пофиг что делать после окончания resolve
        //хотя в тоже время все ок...
        public void Execute(CommandAfterResolveCtx ctx) 
        {
            _systemDevices.SetTargetDeviceState(ctx.DeviceId, ctx.TargetState);
        }
    }
}