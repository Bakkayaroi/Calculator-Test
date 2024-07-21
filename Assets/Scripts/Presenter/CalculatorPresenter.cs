using Model;

namespace Presenter
{
    public class CalculatorPresenter
    {
        private readonly ICalculatorView _view;
        private readonly CalculatorModel _model;

        public CalculatorPresenter(ICalculatorView view, CalculatorModel model)
        {
            _view = view;
            _model = model;

            foreach (var stateHistoryItem in _model.HistoryItems)
            {
                _view.AddHistoryItem(stateHistoryItem.Value);
            }

            _view.SetInput(_model.Input);
        }

        public void OnCalculateClicked(string input)
        {
            var history = _model.Calculate(input);
            _view.AddHistoryItem(history.Value);

            if (history.IsError)
            {
                _view.ShowErrorDialog();
            }
        }

        public void OnApplicationQuit(string input)
        {
            _model.Save(input);
        }
    }
}