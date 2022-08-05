using System;
using System.Collections.Generic;

namespace Source
{
    public class DeviceBuilder : IDeviceBuilder
    {
        private readonly IDeviceViewFactory _deviceViewFactory;
        private readonly ICommandAfterResolve _commandAfterResolve;
        private readonly ISystemLoop _systemLoop;

        private readonly List<IOnMovingAction> _onMovingActions;
        private IMovingStrategy _movingStrategy;
        private CollisionResolverType _collisionResolverType;
        private IDeviceView _view;
        private int _id;

        private IDeviceView View => _view ??= _deviceViewFactory.Create();
        
        public DeviceBuilder(
            IDeviceViewFactory deviceViewFactory,
            ISystemLoop systemLoop,
            ICommandAfterResolve commandAfterResolve)
        {
            _deviceViewFactory = deviceViewFactory;
            _systemLoop = systemLoop;
            _commandAfterResolve = commandAfterResolve;
            _onMovingActions = new List<IOnMovingAction>();
        }
        
        public IDeviceBuilder SetCollisionResolverType(CollisionResolverType collisionResolverType)
        {
            _collisionResolverType = collisionResolverType;
            return this;
        }

        public IDeviceBuilder SetMoveStrategy(AnalogDeviceDto analogDeviceDto)
        {
            _movingStrategy = new MoveDeviceByTime(analogDeviceDto.Position, analogDeviceDto.DurationChange);
            SetId(analogDeviceDto);
            return this;
        }

        public IDeviceBuilder SetMoveStrategy(DiscreteDeviceDto discreteDeviceDto)
        {
            _movingStrategy = new MoveDeviceByTime(discreteDeviceDto.Position, 0);
            SetId(discreteDeviceDto);
            return this;
        }

        public IDeviceBuilder AddRotationToDevice(RotationDeviceActionDto rotationDeviceActionDto)
        {
            var deviceRotator = new DeviceRotator(rotationDeviceActionDto.RotationSpeed);
            var rotationPresenter = new SimpleViewPresenter<Vector3>(() => deviceRotator.Angle, View.Rotation);
            _systemLoop.Attach(rotationPresenter);
            _onMovingActions.Add(deviceRotator);
            return this;
        }

        public Device Build()
        {
            BindMovingStrategy();
            
            var collisionResolver = CreateCollisionResolver(_movingStrategy);
            var device = new Device(collisionResolver, _movingStrategy, _onMovingActions, _id);
            _systemLoop.Attach(device);

            return device;
        }

        private void SetId(BaseDeviceDto baseDeviceDto)
        {
            _id = baseDeviceDto.Id;
        }

        private void BindMovingStrategy()
        {
            var positionPresenter = new SimpleViewPresenter<Vector3>(() => _movingStrategy.Position, View.Position);
            _systemLoop.Attach(positionPresenter);
        }

        private ICollisionResolver CreateCollisionResolver(IMovingStrategy movingStrategy)
        {
            switch (_collisionResolverType)
            {
                case CollisionResolverType.Awaitable:
                    return new AwaitableCollisionResolver(_commandAfterResolve, movingStrategy);
                case CollisionResolverType.Exception:
                    return new ExceptionCollisionResolver();
                case CollisionResolverType.Force:
                    return new ForceCollisionResolver();
                case CollisionResolverType.None:
                default:
                    throw new ArgumentOutOfRangeException(nameof(_collisionResolverType), _collisionResolverType, null);
            }
        }
    }
}