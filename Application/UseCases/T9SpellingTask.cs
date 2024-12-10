using Entities;
using Interfaces;

namespace UseCases
{
    public static class T9SpellingTask
    {
        public static void ProcessFile(string path, int minLines = 1, int maxLines = 100)
        {
            using StreamWriter writer = new ("Output.txt", false);
            
            IInputStateMachine t9InputStateMachine = new T9InputStateMachine(Layouts.t9Layout);
            using StreamReader reader = new(path);
            string? line = reader.ReadLine();
            if (int.TryParse(line?.Trim(), out int numberOfCases))
            {
                if (numberOfCases < minLines || numberOfCases > maxLines)
                {
                    throw new InvalidDataException($"Invalid data in the first input line. Value between {minLines} and {maxLines} is required.");
                }
                
                for (int i = 0; i < numberOfCases; i++)
                {
                    line = reader.ReadLine();
                    if (string.IsNullOrEmpty(line))
                    {
                        throw new InvalidDataException("Empty line.");
                    }

                    try
                    {
                        string result = t9InputStateMachine.EnterLine(line);
                        writer.WriteLine($"Case #{i + 1}: {result}");
                    }
                    catch (KeyNotFoundException ex)
                    {
                        Console.WriteLine(ex.Message);
                        throw;
                    }
                }
            }
            else
            {
                throw new InvalidDataException("Invalid data in the first input line.");
            }
        }
    }
}