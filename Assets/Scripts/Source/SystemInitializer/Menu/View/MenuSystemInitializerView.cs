using UnityEngine;

namespace Source
{
    public sealed class MenuSystemInitializerView : MonoBehaviour, IMenuSystemInitializerView
    {
        [SerializeField] private ButtonTriggerView _spawnAnalogDeviceButton;
        [SerializeField] private ButtonTriggerView _spawnDiscreteDeviceButton;
        [SerializeField] private InputFieldView _durationChangingStateInputField;
        [SerializeField] private InputFieldView _idInputField;

        public IInputView<string> Id => _idInputField;
        public ITriggerView SpawnAnalogDeviceTrigger => _spawnAnalogDeviceButton;
        public ITriggerView SpawnDiscreteDeviceTrigger => _spawnDiscreteDeviceButton;
        public IInputView<string> DurationChangingStateInput => _durationChangingStateInputField;
    }
}