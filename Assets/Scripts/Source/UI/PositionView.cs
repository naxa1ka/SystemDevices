using UnityEngine;

namespace Source
{
    public class PositionView : MonoBehaviour, IView<UnityEngine.Vector3>
    {
        public void SetValue(UnityEngine.Vector3 value)
        {
            transform.position = value;
        }
    }
}