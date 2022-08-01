using System;

namespace Source
{
    public interface IReadOnlyDevice
    {
        int Id { get; }
        Vector3 Position { get; }
        bool IsBusy { get; }
        event Action TaskCompleted;
    }
}