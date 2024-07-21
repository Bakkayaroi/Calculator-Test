namespace Model.Saves
{
    public interface ISaveComponent
    {
        CalculatorState Load();
        void Save(CalculatorState state);
    }
}