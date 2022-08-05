using System.Collections.Generic;
using Newtonsoft.Json;
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

            ICommandAfterResolve commandAfterResolve = new CommandAfterResolve(systemDevices);
            DeviceBuilderFactory deviceBuilderFactory = new DeviceBuilderFactory(deviceViewFactory, systemLoop, commandAfterResolve);
            _jsonSystemInitializer = new JsonSystemInitializer(systemDevices, deviceBuilderFactory);

            DeviceInteractorPresenter deviceInteractorPresenter = new DeviceInteractorPresenter(
                systemDevices,
                systemDevices,
                input,
                _sceneContext.Camera,
                _sceneContext.DeviceInteractorView
            );
            systemLoop.Attach(deviceInteractorPresenter);

            // var json = JsonConvert.SerializeObject(new List<BaseDeviceDto>()
            // {
            //     new AnalogDeviceDto()
            //     {
            //         DeviceActions = new List<object>()
            //         {
            //             new RotationDeviceActionDto()
            //             {
            //                 RotationSpeed = new Vector3(1,1,1),
            //                 Type = DeviceActionDtoType.Rotation
            //             }
            //         },
            //         DurationChange = 10,
            //         Id = 1,
            //         Position = new Vector3(1,1,1),
            //         Type = DeviceDtoType.AnalogDevice,
            //         ResolverType = CollisionResolverType.Awaitable
            //     }
            // });
            // Debug.Log(json);

            
            
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