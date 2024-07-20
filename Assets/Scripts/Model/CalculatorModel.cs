using System.Collections.Generic;
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
                return AddErrorHistory(input);
            }

            var command = _calculateCommandFactory.Create(validateResult);

            if (command == null)
            {
                return AddErrorHistory(input);
            }

            command.Execute();
            return AddResultHistory(input, command.GetResult());
        }

        private HistoryItem AddResultHistory(string input, string result)
        {
            var history = new HistoryItem()
            {
                IsError = false,
                Value = $"{input}={result}"
            };

            _history.Add(history);
            return history;
        }

        private HistoryItem AddErrorHistory(string input)
        {
            var history = new HistoryItem()
            {
                IsError = true,
                Value = $"{input}=ERROR"
            };

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