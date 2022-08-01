using System.Collections.Generic;

namespace Source.Tests
{
    public class StubSystemLoop : ISystemLoop
    {
        public List<IUpdateble> Updatebles;

        public StubSystemLoop()
        {
            Updatebles = new List<IUpdateble>();
        }

        public void Attach(IUpdateble updateble)
        {
            Updatebles.Add(updateble);
        }
    }
}