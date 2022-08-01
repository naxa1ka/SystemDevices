namespace Source
{
    public interface ICommand<in T>
    {
        void Execute(T ctx);
    }
}