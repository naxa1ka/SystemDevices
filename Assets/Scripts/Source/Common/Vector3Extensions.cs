using UnityVector = UnityEngine.Vector3;

namespace Source
{
    public static class Vector3Extensions
    {
        public static UnityVector ToMonoVector3(this Vector3 vector3)
        {
            return new UnityVector(vector3.X, vector3.Y, vector3.Z);
        }

        public static Vector3 FromMonoVector3(this UnityVector vector3)
        {
            return new Vector3(vector3.x, vector3.y, vector3.z);
        }
    }
}