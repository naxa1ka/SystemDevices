using System;
using System.Collections.Generic;
using UnityEngine;

namespace Source
{
    public class DeviceBuilder : IDeviceBuilder
    {
        private readonly IDeviceViewFactory _deviceViewFactory;
        private readonly ISystemLoop _systemLoop;

        private readonly List<MovingAction> _onMovingActions;
        private IMovingStrategy _movingStrategy;
        private CollisionResolverType _collisionResolverType;
        private IDeviceView _view;
        private int _id;

        private IDeviceView View => _view ??= _deviceViewFactory.Create();

        public DeviceBuilder(
            IDeviceViewFactory deviceViewFactory,
            ISystemLoop systemLoop)
        {
            _deviceViewFactory = deviceViewFactory;
            _systemLoop = systemLoop;
            _onMovingActions = new List<MovingAction>();
        }

        public IDeviceBuilder SetCollisionResolverType(CollisionResolverType collisionResolverType)
        {
            _collisionResolverType = collisionResolverType;
            return this;
        }

        public IDeviceBuilder SetMoveStrategy(AnalogDeviceDto analogDeviceDto)
        {
            _movingStrategy = new AnalogMovingStrategy(View.Position, analogDeviceDto.Position, analogDeviceDto.DurationChange);
            SetId(analogDeviceDto);
            return this;
        }

        public IDeviceBuilder SetMoveStrategy(DiscreteDeviceDto discreteDeviceDto)
        {
            _movingStrategy = new DiscreteMovingStrategy(View.Position, discreteDeviceDto.Position);
            SetId(discreteDeviceDto);
            return this;
        }

        public IDeviceBuilder AddRotation(RotationDeviceActionDto dto)
        {
            var rotator = new DeviceRotator(View.Rotation, dto.RotationSpeed);
            _onMovingActions.Add(new MovingAction(rotator, dto.StartTime));
            return this;
        }

        public IDeviceBuilder AddChangingColor(ColorDeviceActionDto dto)
        {
            var colorChanger = new DeviceColorChanger(
                View.Color,
                dto.InitColor.ToUnityColor(),
                dto.TargetColor.ToUnityColor(),
                dto.Duration
            );
            _onMovingActions.Add(new MovingAction(colorChanger, dto.Duration, dto.StartTime));
            return this;
        }

        public Device Build()
        {
            if (_onMovingActions.Count > 0)
                _movingStrategy = new SequenceMovingStrategy(_movingStrategy, _onMovingActions);

            var collisionResolver = CreateCollisionResolver();
            var device = new Device(collisionResolver, _movingStrategy, _id);
            _systemLoop.Attach(device);

            return device;
        }

        private void SetId(BaseDeviceDto baseDeviceDto)
        {
            _id = baseDeviceDto.Id;
        }

        private ICollisionResolver CreateCollisionResolver()
        {
            switch (_collisionResolverType)
            {
                case CollisionResolverType.AwaitableQueue:
                    return new QueueAwaitableCollisionResolver();
                case CollisionResolverType.Awaitable:
                    return new AwaitableCollisionResolver();
                case CollisionResolverType.Exception:
                    return new ExceptionCollisionResolver();
                case CollisionResolverType.Force:
                    return new ForceCollisionResolver();
                default:
                    throw new ArgumentOutOfRangeException(nameof(_collisionResolverType), _collisionResolverType, null);
            }
        }
    }
}