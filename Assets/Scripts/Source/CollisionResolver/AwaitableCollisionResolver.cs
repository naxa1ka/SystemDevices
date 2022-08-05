using System;
using System.Threading.Tasks;

namespace Source
{
    public sealed class AwaitableCollisionResolver : ICollisionResolver
    {
        private readonly ICommandAfterResolve _commandAfterResolve;
        private readonly IAwaitableStrategy _awaitableStrategy;

        public AwaitableCollisionResolver(ICommandAfterResolve commandAfterResolve, IAwaitableStrategy awaitableStrategy)
        {
            _commandAfterResolve = commandAfterResolve;
            _awaitableStrategy = awaitableStrategy;
        }

        public async void Resolve(int deviceId, Vector3 targetPosition, Action onResolved)
        {
            var collisionResolver = new AwaiterBusyDevice(_awaitableStrategy);
            await collisionResolver.WaitEndActionDevice();
            onResolved.Invoke();
        }

        public async void Resolve(int deviceId, Vector3 targetPosition)
        {
            
        }

        private sealed class AwaiterBusyDevice
        {
            private struct Unit
            {
            }
            
            private readonly IAwaitableStrategy _awaitableStrategy;
            private TaskCompletionSource<Unit> _taskCompletionSource;

            public AwaiterBusyDevice(IAwaitableStrategy awaitableStrategy)
            {
                _awaitableStrategy = awaitableStrategy;
            }

            public async Task WaitEndActionDevice()
            {
                _taskCompletionSource = new TaskCompletionSource<Unit>();
                _awaitableStrategy.TaskCompleted += OnTaskCompleted;
                await _taskCompletionSource.Task;
            }

            private void OnTaskCompleted()
            {
                _awaitableStrategy.TaskCompleted -= OnTaskCompleted;
                _taskCompletionSource.SetResult(new Unit());
            }
        }
    }
}