using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Source
{
    public class DropDownListView<T> : MonoBehaviour, IListView<T>
    {
        [SerializeField] private TMP_Dropdown _dropDown;
        
        public void SetValue(IEnumerable<T> value)
        {
            _dropDown.options.Clear();
            foreach (var item in value)
            {
                _dropDown.options.Add(new TMP_Dropdown.OptionData(item.ToString()));
            }

            _dropDown.RefreshShownValue();
        }
    }
}