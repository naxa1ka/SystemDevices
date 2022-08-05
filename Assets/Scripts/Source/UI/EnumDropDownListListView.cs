using System;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

namespace Source
{
    public class EnumDropDownListListView<T> : MonoBehaviour, IEnumDropDownList<T> where T : Enum
    {
        [SerializeField] private TMP_Dropdown _dropDown;
        private List<T> _listEnums;

        public T Value => _listEnums[_dropDown.value];

        public void SetValue(IEnumerable<T> value)
        {
            _listEnums = value.ToList();
            _dropDown.ClearOptions();
            foreach (var item in _listEnums)
            {
                _dropDown.options.Add(new TMP_Dropdown.OptionData(item.ToString()));
            }
        }
    }
}