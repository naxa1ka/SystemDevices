namespace Source
{
    public class Input : IInput
    {
        public UnityEngine.Vector3 MousePosition => UnityEngine.Input.mousePosition;
        public bool WasLKMClicked => UnityEngine.Input.GetMouseButtonDown(0);
    }
}