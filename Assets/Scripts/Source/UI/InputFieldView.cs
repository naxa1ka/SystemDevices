using UnityEngine;
using UnityEngine.UI;

namespace Source
{
    public class InputFieldView: MonoBehaviour, IInputView<string>
    {
        [SerializeField] private InputField _inputField;
        public string Value => _inputField.text;
    }
}