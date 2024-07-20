using Model;
using View;

namespace Presenter
{
    public class CalculatorPresenter
    {
        private readonly CalculatorView _view;
        private readonly CalculatorModel _model;

        public CalculatorPresenter(CalculatorView view, CalculatorModel model)
        {
            _view = view;
            _model = model;
            var state = _model.Load();

            foreach (var stateHistoryItem in state.HistoryItems)
            {
                _view.AddHistoryItem(stateHistoryItem.Value);
            }

            _view.SetInput(state.Input);
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