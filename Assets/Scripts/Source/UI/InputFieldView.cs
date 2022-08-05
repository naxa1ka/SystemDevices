using TMPro;
using UnityEngine;

namespace Source
{
    public class InputFieldView: MonoBehaviour, IInputView<string>
    {
        [SerializeField] private TMP_InputField _inputField;
        public string Value => _inputField.text;
    }
}