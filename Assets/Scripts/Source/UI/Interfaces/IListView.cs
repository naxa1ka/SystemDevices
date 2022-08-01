using System.Collections.Generic;

namespace Source
{
    public interface IListView<in T> : IView<IEnumerable<T>>
    {
        
    }
}