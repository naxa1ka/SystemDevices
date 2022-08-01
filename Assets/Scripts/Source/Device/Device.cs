using System;

namespace Source
{
    public abstract class Device : IReadOnlyDevice
    {
        public int Id { get; }
        public Vector3 Position { protected set; get; }
        public bool IsBusy { protected set; get; }

        public event Action TaskCompleted;

        protected Device(int id, Vector3 position)
        {
            Id = id;
            Position = position;
        }

        public abstract void SetTargetPosition(Vector3 targetPosition);

        protected void OnComplete()
        {
            IsBusy = false;
            TaskCompleted?.Invoke();
        }
    }
}