using System.Threading.Tasks;

namespace Source
{
    public sealed class AwaitableCollisionResolver : ICollisionResolver
    {
        private readonly ICommandAfterResolve _commandAfterResolve;

        public AwaitableCollisionResolver(ICommandAfterResolve commandAfterResolve)
        {
            _commandAfterResolve = commandAfterResolve;
        }

        public async void Resolve(IReadOnlyDevice device, Vector3 targetPosition)
        {
            var collisionResolver = new AwaiterBusyDevice(device);
            await collisionResolver.WaitEndActionDevice();
            _commandAfterResolve.Execute(new CommandAfterResolveCtx(device.Id, targetPosition));
        }

        private sealed class AwaiterBusyDevice
        {
            private struct Unit
            {
            }

            private readonly IReadOnlyDevice _device;
            private TaskCompletionSource<Unit> _taskCompletionSource;

            public AwaiterBusyDevice(IReadOnlyDevice device)
            {
                _device = device;
            }

            public async Task WaitEndActionDevice()
            {
                _taskCompletionSource = new TaskCompletionSource<Unit>();
                _device.TaskCompleted += OnTaskCompleted;
                await _taskCompletionSource.Task;
            }

            private void OnTaskCompleted()
            {
                _device.TaskCompleted -= OnTaskCompleted;
                _taskCompletionSource.SetResult(new Unit());
            }
        }
    }
}