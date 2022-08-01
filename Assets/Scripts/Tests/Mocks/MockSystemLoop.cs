using System.Collections.Generic;

namespace Source.Tests
{
    public class MockSystemLoop : ISystemLoop
    {
        private readonly List<IUpdateble> _updatebles;

        public MockSystemLoop()
        {
            _updatebles = new List<IUpdateble>();
        }
        
        public void Attach(IUpdateble updateble)
        {
            _updatebles.Add(updateble);
        }

        public void Update(float dt)
        {
            foreach (var updateble in _updatebles)
            {
                updateble.Update(dt);
            }
        }
    }
}