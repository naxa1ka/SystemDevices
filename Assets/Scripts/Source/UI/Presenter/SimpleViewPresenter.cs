using System;

namespace Source
{
    public class SimpleViewPresenter<T> : IUpdateble
    {
        private readonly Func<T> _getter;
        private readonly IView<T> _view;

        public SimpleViewPresenter(Func<T> getter, IView<T> view)
        {
            _getter = getter;
            _view = view;
        }

        public void Update(float dt)
        {
            _view.SetValue(_getter.Invoke());
        }
    }
}