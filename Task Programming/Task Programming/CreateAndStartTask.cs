using System;
using System.Threading;
using System.Threading.Tasks;

namespace TaskProgramming
{
    internal static class CreateAndStartTask
    {

        public static void Write(char c)
        {
            int i = 1000;
            while(i --> 0)
            {
                Console.Write(c);
            }
        }

        public static void Write(Object o)
        {
            int i = 1000;
            while (i-- > 0)
            {
                Console.Write(o);
            }
        }

        public static int TextLength(Object o)
        {
            //Get current Task Id
            Console.WriteLine($"\nTask with id {Task.CurrentId} processing object {o}...");
            return o.ToString().Length;
        }

        public static void Main()
        {
            //Create Task using System.Threading.Tasks

            /*Task.Factory.StartNew(() => Write('.'));

            var t = new Task(() => Write('?'));
            t.Start();

            Write('-');*/

            /*Task task = new Task(Write, "Hello");
            task.Start();
            Task.Factory.StartNew(Write, 123);*/

            //Get Result from a Task
            string text1 = "testing", text2 = "this";
            var task1 = new Task<int>(TextLength, text1);
            task1.Start();

            Task<int> task2 = Task.Factory.StartNew(TextLength, text2);

            Console.WriteLine($"length of '{task1}' is {task1.Result}");
            Console.WriteLine($"length of '{task2}' is {task2.Result}");

            Console.WriteLine("Main method");
        }
    }
}