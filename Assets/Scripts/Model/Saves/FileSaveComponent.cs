using System.IO;
using System.Reflection;
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

        public void Save(CalculatorState state)
        {
            File.WriteAllText(GetPath(), JsonUtility.ToJson(state));
        }

        private string GetPath()
        {
            var path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            return Path.Combine(path, HistoryFilePath);
        }
    }
}