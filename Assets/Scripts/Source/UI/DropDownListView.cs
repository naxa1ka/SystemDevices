using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Source
{
    public class DropDownListView<T> : MonoBehaviour, IListView<T>
    {
        [SerializeField] private Dropdown _dropDown;
        
        public void SetValue(IEnumerable<T> value)
        {
            _dropDown.options.Clear();
            foreach (var item in value)
            {
                _dropDown.options.Add(new Dropdown.OptionData(item.ToString()));
            }
        }
    }
}