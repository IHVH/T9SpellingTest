namespace Interfaces
{
    public interface IInputStateMachine
    {
        Dictionary<char, (int, string)> Layout { get; }

        string EnterLine(string line);
        string EnterSymbol(char symbol);
        void ResetState();
    }
}
