using UnityEngine;

namespace Source
{
    public sealed class MenuSystemInitializerView : MonoBehaviour, IMenuSystemInitializerView
    {
        [SerializeField] private ButtonTriggerView _spawnDeviceButton;
        [SerializeField] private InputFieldView _durationChangingStateInputField;
        [SerializeField] private InputFieldView _idInputField;
        [SerializeField] private CollisionResolverEnumDropDownListView _collisionResolverEnumDropDownListView;

        public IInputView<string> IdInput => _idInputField;
        public ITriggerView SpawnDeviceTrigger => _spawnDeviceButton;
        public IInputView<string> DurationChangingStateInput => _durationChangingStateInputField;
        public IEnumDropDownList<CollisionResolverType> CollisionResolverType => _collisionResolverEnumDropDownListView;
    }
}