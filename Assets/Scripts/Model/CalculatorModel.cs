using System.Collections.Generic;
using Model.History;
using Model.Saves;
using Model.Validations;

namespace Model
{
    public class CalculatorModel
    {
        private ISaveComponent _saveComponent = new FileSaveComponent();
        private List<HistoryItem> _history = new();
        private readonly CalculateCommandFactory _calculateCommandFactory = new();

        public HistoryItem Calculate(string input)
        {
            var validateResult = CalculatorInputValidator.Validate(input);
            if (validateResult == null)
            {
                return AddHistory(false, input);
            }

            var command = _calculateCommandFactory.Create(validateResult);

            if (command == null)
            {
                return AddHistory(false, input);
            }

            command.Execute();
            return AddHistory(true, input, command.GetResult());
        }

        private HistoryItem AddHistory(bool isError, string input, string result = null)
        {
            var history = HistoryFormatter.Format(isError, input, result);
            _history.Add(history);
            return history;
        }

        public CalculatorState Load()
        {
            var state = _saveComponent.Load();
            _history = state.HistoryItems;
            return state;
        }

        public void Save(string input)
        {
            _saveComponent.Save(input, _history);
        }
    }
}