using Interfaces;

namespace Entities.Tests
{
    public class T9InputStateMachineTests
    {
        [Fact]
        public void Initialization()
        {
            IInputStateMachine t9InputStateMachine = new T9InputStateMachine(testLayout);
            
            Assert.NotNull(t9InputStateMachine);
            Assert.Equal(testLayout.Count, t9InputStateMachine.Layout.Count);
        }

        [Fact]
        public void EnterLine()
        {
            IInputStateMachine t9InputStateMachine = new T9InputStateMachine(testLayout);

            string result1 = t9InputStateMachine.EnterLine("hi");
            string result2 = t9InputStateMachine.EnterLine("yes");
            string result3 = t9InputStateMachine.EnterLine("foo  bar");
            string result4 = t9InputStateMachine.EnterLine("hello world");

            Assert.Equal("44 444", result1);
            Assert.Equal("999337777", result2);
            Assert.Equal("333666 6660 022 2777", result3);
            Assert.Equal("4433555 555666096667775553", result4);
        }

        [Fact]
        public void EnterLineDubleSpace()
        {
            IInputStateMachine t9InputStateMachine = new T9InputStateMachine(testLayout);

            string result1 = t9InputStateMachine.EnterLine("  ");
            
            Assert.Equal("0 0", result1);
        }

        [Fact]
        public void EnterSymbol()
        {
            IInputStateMachine t9InputStateMachine = new T9InputStateMachine(testLayout);

            string result1 = t9InputStateMachine.EnterSymbol('h');
            string result2 = t9InputStateMachine.EnterSymbol('i');
            
            Assert.Equal("44", result1);
            Assert.Equal(" 444", result2);
        }

        [Fact]
        public void ResetState()
        {
            IInputStateMachine t9InputStateMachine = new T9InputStateMachine(testLayout);

            string result1 = t9InputStateMachine.EnterSymbol('h');
            t9InputStateMachine.ResetState();
            string result2 = t9InputStateMachine.EnterSymbol('i');

            Assert.Equal("44", result1);
            Assert.Equal("444", result2);
        }

        private static readonly Dictionary<char, (int, string)> testLayout = new()
        {
            { ' ', (0, "0") },
            { 'a', (2, "2") },
            { 'b', (2, "22") },
            { 'c', (2, "222") },
            { 'd', (3, "3") },
            { 'e', (3, "33") },
            { 'f', (3, "333") },
            { 'g', (4, "4") },
            { 'h', (4, "44") },
            { 'i', (4, "444") },
            { 'j', (5, "5") },
            { 'k', (5, "55") },
            { 'l', (5, "555") },
            { 'm', (6, "6") },
            { 'n', (6, "66") },
            { 'o', (6, "666") },
            { 'p', (7, "7") },
            { 'q', (7, "77") },
            { 'r', (7, "777") },
            { 's', (7, "7777") },
            { 't', (8, "8") },
            { 'u', (8, "88") },
            { 'v', (8, "888") },
            { 'w', (9, "9") },
            { 'x', (9, "99") },
            { 'y', (9, "999") },
            { 'z', (9, "9999") },
        };
    }
}