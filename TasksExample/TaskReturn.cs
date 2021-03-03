using System;
using System.Collections.Generic;
using System.Text;

namespace TasksExample
{
    public class TaskReturn<T> : ITaskReturn
    {
        public T Value { get; set; }
        public OperationType Key { get ; set; }
    }
}
