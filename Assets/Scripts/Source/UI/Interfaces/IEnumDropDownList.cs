using System;

namespace Source
{
    public interface IEnumDropDownList<T> : IListView<T>, IInputView<T> where T : Enum
    {
        
    }
}