using Entities;
using Interfaces;
using UseCases;

Console.WriteLine("T9 Spelling Task");
T9SpellingTask.ProcessFile("Input.txt");

//CheckPerformance performance = new(100000);
//IInputStateMachine t9InputStateMachine = new T9InputStateMachine(Layouts.t9Layout);
//IInputStateMachine t9InputStateMachine = new T9InputByteStateMachine(Layouts.t9Layout);
//performance.Check(t9InputStateMachine);