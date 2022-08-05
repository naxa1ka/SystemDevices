using UnityEngine;

namespace Source
{
    public class PositionView : MonoBehaviour, IView<Vector3>
    {
        public void SetValue(Vector3 value)
        {
            transform.position = value.ToMonoVector3();
        }
    }
}