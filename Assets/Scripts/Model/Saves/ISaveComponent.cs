using System.Collections.Generic;

namespace Model.Saves
{
    public interface ISaveComponent
    {
        CalculatorState Load();
        void Save(string input, List<HistoryItem> historyItems);
    }
}