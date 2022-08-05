using System;

namespace Source
{
    public interface IAwaitableStrategy
    {
        public bool IsBusy { get; }
        public event Action TaskCompleted;
    }
}