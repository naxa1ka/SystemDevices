namespace Source
{
    public interface IDeviceInteractorView
    {
        public IListView<int> ListIdDevices { get; }
        public IInputView<int> SelectedIndex { get; }
    }
}