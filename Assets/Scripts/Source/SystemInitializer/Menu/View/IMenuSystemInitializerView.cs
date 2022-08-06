namespace Source
{
    public interface IMenuSystemInitializerView
    {
        ITriggerView SpawnDeviceTrigger { get; }
        IInputView<string> DurationChangingStateInput { get; }
        IInputView<string> IdInput { get; }
        IEnumDropDownList<CollisionResolverType> CollisionResolverType { get; }
    }
}