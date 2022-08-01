using System.Collections.Generic;
using UnityEngine;

namespace Source
{
    public class GameSystemLoop : MonoBehaviour, ISystemLoop
    {
        private readonly List<IUpdateble> _list = new List<IUpdateble>();

        public void Attach(IUpdateble updateble)
        {
            _list.Add(updateble);
        }

        private void Update()
        {
            foreach (var updateble in _list)
            {
                updateble.Update(Time.deltaTime);
            }
        }
    }
}