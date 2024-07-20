namespace Model.Commands.Interfaces
{
    public interface IResultCommand<out TResult> : ICommand
    {
        TResult GetResult();
    }
}