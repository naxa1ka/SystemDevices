namespace Source
{
    public interface IInputView<out T>
    {
        T Value { get; }
    }
}