namespace Model.History
{
    public abstract class HistoryFormatter
    {
        public static HistoryItem Format(bool isError, string input, string result = null)
        {
            if (isError)
            {
                return new HistoryItem
                {
                    IsError = true,
                    Value = $"{input}=ERROR"
                };
            }

            return new HistoryItem
            {
                IsError = false,
                Value = $"{input}={result}"
            };
        }
    }
}