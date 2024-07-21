using System.Collections.Generic;
using Model.History;
using Model.Saves;
using Model.Validations;

namespace Model
{
    public class CalculatorModel
    {
        public List<HistoryItem> HistoryItems => _state.HistoryItems;
        public string Input => _state.Input;

        private readonly ISaveComponent _saveComponent = new FileSaveComponent();
        private readonly CalculateCommandFactory _calculateCommandFactory = new();
        private CalculatorState _state;

        public CalculatorModel()
        {
            Load();
        }

        public HistoryItem Calculate(string input)
        {
            var validateResult = CalculatorInputValidator.Validate(input);
            if (validateResult == null)
            {
                return AddHistory(true, input);
            }

            var command = _calculateCommandFactory.Create(validateResult);
            if (command == null)
            {
                return AddHistory(true, input);
            }

            command.Execute();
            return AddHistory(false, input, command.GetResult());
        }

        private HistoryItem AddHistory(bool isError, string input, string result = null)
        {
            var history = HistoryFormatter.Format(isError, input, result);
            _state.HistoryItems.Add(history);
            return history;
        }

        private void Load()
        {
            _state = _saveComponent.Load();
        }

        public void Save(string input)
        {
            _state.Input = input;
            _saveComponent.Save(_state);
        }
    }
}