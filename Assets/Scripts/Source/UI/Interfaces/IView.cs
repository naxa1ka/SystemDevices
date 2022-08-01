namespace Source
{
    public interface IView<in T>
    {
        void SetValue(T value);
    }
}