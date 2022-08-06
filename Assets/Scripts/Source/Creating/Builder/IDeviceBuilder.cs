namespace Source
{
    public interface IDeviceBuilder
    {
        IDeviceBuilder SetCollisionResolverType(CollisionResolverType collisionResolverType);
        IDeviceBuilder SetMoveStrategy(AnalogDeviceDto analogDeviceDto);
        IDeviceBuilder SetMoveStrategy(DiscreteDeviceDto discreteDeviceDto);
        IDeviceBuilder AddRotation(RotationDeviceActionDto dto);
        IDeviceBuilder AddChangingColor(ColorDeviceActionDto dto);
        Device Build();
    }
}