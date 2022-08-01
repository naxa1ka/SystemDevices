namespace Source
{
    public interface IMenuSystemInitializerView
    {
        ITriggerView SpawnAnalogDeviceTrigger { get; }
        ITriggerView SpawnDiscreteDeviceTrigger { get; }
        IInputView<string> DurationChangingStateInput { get; }
        IInputView<string> Id { get; }
    }
}