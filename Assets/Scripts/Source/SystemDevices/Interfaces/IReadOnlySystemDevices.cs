using System.Collections.Generic;

namespace Source
{
    public interface IReadOnlySystemDevices
    {
        public List<int> ListId { get; }
        public bool TryGetDevice(int id, out IReadOnlyDevice device);
    }
}