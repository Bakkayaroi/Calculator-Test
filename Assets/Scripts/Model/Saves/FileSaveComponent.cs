using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Model.History;
using UnityEngine;

namespace Model.Saves
{
    public class FileSaveComponent : ISaveComponent
    {
        private const string HistoryFilePath = "save.json";

        public CalculatorState Load()
        {
            var state = File.Exists(GetPath())
                ? JsonUtility.FromJson<CalculatorState>(File.ReadAllText(GetPath()))
                : new();
            return state;
        }

        public void Save(string input, List<HistoryItem> historyItems)
        {
            File.WriteAllText(GetPath(), JsonUtility.ToJson(new CalculatorState
            {
                Input = input,
                HistoryItems = historyItems
            }));
        }

        private string GetPath()
        {
            var path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            return Path.Combine(path, HistoryFilePath);
        }
    }
}