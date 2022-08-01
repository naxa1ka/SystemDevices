using UnityEngine;
using UnityEngine.UI;

namespace Source
{
    public class DropDownSelectedItemView : MonoBehaviour, IInputView<int>
    {
        [SerializeField] private Dropdown _dropDown;
        public int Value => _dropDown.value;
    }
}