using UnityEngine;

namespace Source
{
    public class DeviceInteractorView : MonoBehaviour, IDeviceInteractorView
    {
        [SerializeField] private DropDownListView<int> _listIdDevices;
        [SerializeField] private DropDownSelectedItemView _dropDownSelectedItemView;
        public IListView<int> ListIdDevices => _listIdDevices;
        public IInputView<int> SelectedIndex => _dropDownSelectedItemView;
    }
}