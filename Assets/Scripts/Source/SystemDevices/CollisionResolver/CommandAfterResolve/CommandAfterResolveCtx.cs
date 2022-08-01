namespace Source
{
    public readonly struct CommandAfterResolveCtx
    {
        public readonly int DeviceId;
        public readonly Vector3 TargetState;

        public CommandAfterResolveCtx(int deviceId, Vector3 targetState)
        {
            DeviceId = deviceId;
            TargetState = targetState;
        }
    }
}