namespace Source
{
    public interface IDeviceBuilder
    {
        IDeviceBuilder SetCollisionResolverType(CollisionResolverType collisionResolverType);
        IDeviceBuilder SetMoveStrategy(AnalogDeviceDto analogDeviceDto);
        IDeviceBuilder SetMoveStrategy(DiscreteDeviceDto discreteDeviceDto);
        IDeviceBuilder AddRotationToDevice(RotationDeviceActionDto rotationDeviceActionDto);
        Device Build();
    }
}