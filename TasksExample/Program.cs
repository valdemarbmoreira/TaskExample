using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TasksExample
{
    class Program
    {
        static void Main(string[] args)
        {

            var tarefas = new List<Task<ITaskReturn>>
            {
                Task.Run(() => GetSoma(OperationType.SUM01)),
                Task.Run(() => GetSoma(OperationType.SUM02)),
                Task.Run(() => GetWord())
            };

            Task.WaitAll(tarefas.ToArray());

            var sum1 = GetValue<List<Horse>>(tarefas, OperationType.SUM01);
            var sum2 = GetValue<List<Horse>>(tarefas, OperationType.SUM02);
            var words = GetValue<string>(tarefas, OperationType.WORDS);

            //var sum1 = GetSoma(OperationType.SUM01);
            //var sum2 = GetSoma(OperationType.SUM02);
            //var words = GetWord();

            Console.WriteLine("Hello World!");
        }

        public static T GetValue<T>(List<Task<ITaskReturn>> tasks, OperationType type)
        {
            return (tasks.FirstOrDefault(f => f.Result.Key == type).Result as TaskReturn<T>).Value;
        }

        public static ITaskReturn GetSoma(OperationType type)
        {
            var result = new List<Horse>();
            foreach (var value in Enumerable.Range(1,10000000))
            {
                result.Add(new Horse
                {
                    Age = value,
                    Name = $"Hourse -{value}"
                });
            }

            return new TaskReturn<List<Horse>>
            {
                Key = type,
                Value = result
            };
        }

        public static ITaskReturn GetWord()
        {

            return new TaskReturn<string>
            {
                Key = OperationType.WORDS,
                Value = "test"
            };
        }
    }
}

