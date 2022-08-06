using UnityEngine;

namespace Source
{
    public class Bootstrap : MonoBehaviour
    {
        [SerializeField] private SceneContext _sceneContext;

        private JsonSystemInitializer _jsonSystemInitializer;

        private void Awake()
        {
            ISystemLoop systemLoop = _sceneContext.GameSystemLoop;
            IDeviceViewFactory deviceViewFactory = new DeviceViewFactory(_sceneContext.DeviceView);
            IInput input = new Input();

            var systemDevices = new SystemDevices();

            DeviceBuilderFactory deviceBuilderFactory = new DeviceBuilderFactory(deviceViewFactory, systemLoop);
            _jsonSystemInitializer = new JsonSystemInitializer(systemDevices, deviceBuilderFactory);

            DeviceInteractorPresenter deviceInteractorPresenter = new DeviceInteractorPresenter(
                systemDevices,
                systemDevices,
                input,
                _sceneContext.Camera,
                _sceneContext.DeviceInteractorView
            );
            systemLoop.Attach(deviceInteractorPresenter);

            MenuSystemInitializerPresenter menuSystemInitializerPresenter =
                new MenuSystemInitializerPresenter(
                    _sceneContext.MenuSystemInitializerView,
                    systemDevices,
                    deviceBuilderFactory,
                    systemDevices);
        }

        private void Start()
        {
            var json = Resources.Load<TextAsset>("StartDevices").text;
            _jsonSystemInitializer.AddDevices(json);
        }
    }
}