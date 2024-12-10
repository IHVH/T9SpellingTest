using Interfaces;
using System.Text;

namespace Entities
{
    public struct T9InputStateMachine(Dictionary<char, (int, string)> layout) : IInputStateMachine
    {
        private int previousDigit = -1;
        public readonly Dictionary<char, (int, string)> Layout { get; } = layout;

        public string EnterLine(string line)
        {
            StringBuilder result = new ();
            foreach (var symbol in line)
            {
                result.Append(EnterSymbol(symbol));
            }
            ResetState();
            return result.ToString();
        }

        public string EnterSymbol(char symbol)
        {
            var (digit, sequenceNumbers) = Layout[symbol];
            if (digit == previousDigit)
            {
                return " " + sequenceNumbers;
            }
            else
            {
                previousDigit = digit;
                return sequenceNumbers;
            }
        }

        public void ResetState()
        {
            previousDigit = -1;
        }
    }
}
