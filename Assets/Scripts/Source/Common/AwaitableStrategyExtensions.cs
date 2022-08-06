using System.Threading.Tasks;

namespace Source
{
    public static class AwaitableStrategyExtensions
    {
        public static Task Await(this IAwaitableStrategy awaitableStrategy)
        {
            var collisionResolver = new AwaiterBusyDevice(awaitableStrategy);
            return collisionResolver.WaitEndActionDevice();
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