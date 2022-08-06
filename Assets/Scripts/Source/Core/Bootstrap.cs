using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
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

            var json = JsonConvert.SerializeObject(new List<BaseDeviceDto>()
            {
                new AnalogDeviceDto()
                {
                    DeviceActions = new List<object>()
                    {
                        new RotationDeviceActionDto()
                        {
                            RotationSpeed = new Vector3(1,1,1),
                            StartTime = 0.25f,
                            Type = DeviceActionDtoType.Rotation
                        },
                        new ColorDeviceActionDto()
                        {
                            InitColor = new SerializableColor(new Color(100, 128, 128)),
                            TargetColor = new SerializableColor(new Color(222, 256, 256)),
                            StartTime = 0.25f,
                            Type = DeviceActionDtoType.Color
                        },
                        new ColorDeviceActionDto()
                        {
                            InitColor = new SerializableColor(new Color(0, 0, 0)),
                            TargetColor = new SerializableColor(new Color(128, 128, 128)),
                            StartTime = 0.25f, 
                            Type = DeviceActionDtoType.Color
                        }
                    },
                    DurationChange = 10,
                    Id = 1,
                    Position = new Vector3(1,1,1),
                    Type = DeviceDtoType.AnalogDevice,
                    ResolverType = CollisionResolverType.Awaitable
                }
            }, new StringEnumConverter());
            Debug.Log(json);


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