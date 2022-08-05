using UnityEngine;

namespace Source
{
    public class RotationView : MonoBehaviour, IView<Vector3>
    {
        public void SetValue(Vector3 value)
        {
            transform.eulerAngles = value.ToMonoVector3();
        }
    }
}