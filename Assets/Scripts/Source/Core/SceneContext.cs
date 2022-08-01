using UnityEngine;

namespace Source
{
    public class SceneContext : MonoBehaviour
    {
        [field: SerializeField] public Camera Camera { get; private set; }
        [field: SerializeField] public GameSystemLoop GameSystemLoop { get; private set; }
        [field: SerializeField] public DeviceView DeviceView { get; private set; }
        [field: SerializeField] public DeviceInteractorView DeviceInteractorView { get; private set; }
        [field: SerializeField] public MenuSystemInitializerView MenuSystemInitializerView { get; private set; }
    }
}