namespace Presenter
{
    public interface ICalculatorView
    {
        void AddHistoryItem(string history);
        void SetInput(string stateInput);
        void ShowErrorDialog();
    }
}