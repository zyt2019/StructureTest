using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<string> stringStack = new Stack<string>(1);
            stringStack.Push("1");
            stringStack.Push("2");
            stringStack.Push("3");
            Console.WriteLine(stringStack.Peek()) ;
            Console.ReadKey();
        }
    }
    public class CommandStack
    {
        public Stack<Command> _commandStack {private set; get; }
        int _capacity;
        public CommandStack(int commandCapacity)
        {
            this._commandStack = new Stack<Command>(commandCapacity);
            this._capacity = commandCapacity;
        }
        public bool IsFull()
        {
            return _commandStack.Count >= this._capacity;
        }
        public bool IsEmpty()
        {
            return _commandStack.Count == 0;
        }
        public bool PerformCommand(Command command)
        {
            if (!this.IsFull())
            {
                this._commandStack.Push(command);
                return true;
            }
            return false;
        }
        public bool PerformCommands(List<Command> commands)
        {
            bool inserted = true;
            foreach (var c in commands)
            {
                inserted = PerformCommand(c);
            }
            return inserted;
        }
        public Command UndoCommand()
        {
            return this._commandStack.Pop();
        }
        public void Reset()
        {
            this._commandStack.Clear();
        }
        public int TotalCommands()
        {
            return this._commandStack.Count;
        }
    }
}
