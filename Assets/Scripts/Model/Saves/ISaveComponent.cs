using System.Collections.Generic;
using Model.History;

namespace Model.Saves
{
    public interface ISaveComponent
    {
        CalculatorState Load();
        void Save(string input, List<HistoryItem> historyItems);
    }
}