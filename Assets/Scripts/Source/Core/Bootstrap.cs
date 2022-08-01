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
            IDeviceFactory deviceFactory = new DeviceFactory(deviceViewFactory, systemLoop);
            IInput input = new Input();

            var commonSystemDevices = new CommonSystemDevices();
            IMutableSystemDevices mutableSystemDevices = commonSystemDevices;
            IReadOnlySystemDevices readOnlySystemDevices = commonSystemDevices;

            ICommandAfterResolve commandAfterResolve = new CommandAfterResolve(commonSystemDevices);
            ICollisionResolver collisionResolver = new AwaitableCollisionResolver(commandAfterResolve);

            ISystemDevices systemDevices = new SystemDevicesWithCollisionResolver(
                commonSystemDevices,
                commonSystemDevices,
                collisionResolver
            );


            ISystemInitializer systemInitializer = new SystemInitializer(mutableSystemDevices, deviceFactory);
            _jsonSystemInitializer = new JsonSystemInitializer(systemInitializer);

            DeviceInteractorPresenter deviceInteractorPresenter = new DeviceInteractorPresenter(
                readOnlySystemDevices,
                systemDevices,
                input,
                _sceneContext.Camera,
                _sceneContext.DeviceInteractorView
            );
            systemLoop.Attach(deviceInteractorPresenter);
            
            MenuSystemInitializerPresenter menuSystemInitializerPresenter =
                new MenuSystemInitializerPresenter(
                    _sceneContext.MenuSystemInitializerView,
                    systemInitializer,
                    readOnlySystemDevices);
        }

        private void Start()
        {
            var json = Resources.Load<TextAsset>("StartDevices").text;
            _jsonSystemInitializer.AddDevices(json);
        }
    }
}