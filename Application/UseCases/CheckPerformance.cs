using Interfaces;
using System.Diagnostics;

namespace UseCases
{
    public class CheckPerformance
    {
        private readonly int lineLength = 1000;
        private readonly string chars = " abcdefghijklmnopqrstuvwxyz";
        private readonly List<string> lines;

        public CheckPerformance(int numberCases, string? chars = null)
        {
            if (!string.IsNullOrEmpty(chars))
            {
                this.chars = chars;
            }
            lines = GenerateData(numberCases);
        }

        private List<string> GenerateData(int NumberCases)
        {
            List<string> lines = new(NumberCases);
            var random = new Random();
            for (int i = 0; i < NumberCases; i++)
            {
                var rndChars = new char[lineLength];
                for (int j = 0; j < lineLength; j++)
                {
                    rndChars[j] = chars[random.Next(chars.Length)];
                }
                lines.Add(new string(rndChars));
            }
            return lines;
        }

        public void Check(IInputStateMachine inputStateMachine)
        {
            Stopwatch sw = new ();
            sw.Start();

            for (int i = 0; i < lines.Count; i++)
            {
                inputStateMachine.EnterLine(lines[i]);
            }

            //foreach (var line in lines)
            //{
            //    inputStateMachine.EnterLine(line);
            //}
            sw.Stop();
            TimeSpan ts = sw.Elapsed;
            string rt = string.Format("{0:00}:{1:00}:{2:00}.{3}", ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds);
            Console.WriteLine($"RunTime = {rt}");
        }
    }
}