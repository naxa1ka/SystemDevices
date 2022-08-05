using TMPro;
using UnityEngine;

namespace Source
{
    public class DropDownSelectedItemView : MonoBehaviour, IInputView<int>
    {
        [SerializeField] private TMP_Dropdown _dropDown;
        public int Value => _dropDown.value;
    }
}