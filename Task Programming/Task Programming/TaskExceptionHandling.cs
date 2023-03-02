using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskProgramming
{
    internal class TaskExceptionHandling
    {
        private static void RunTask()
        {
            var t1 = Task.Factory.StartNew(() =>
            {
                throw new InvalidOperationException("Cant do this") { Source = "t1" };
            });

            var t2 = Task.Factory.StartNew(() =>
            {
                throw new AccessViolationException("Cant do this") { Source = "t2", };
            });

            try
            {
                Task.WaitAll(t1, t2);
            }
            catch (AggregateException ae)
            {
                ae.Handle(e =>
                {
                    if (e is InvalidOperationException)
                    {
                        Console.WriteLine("Handle InvalidOperationException");
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                });
            }
        }
        public static void Main()
        {
            try
            {
                RunTask();
            }
            catch(AggregateException ae)
            {
                foreach(var e in ae.InnerExceptions)
                {
                    Console.WriteLine($"Handle in main {e.GetType()}");
                }
            }
            
            Console.WriteLine("Main method");
            Console.ReadKey();
        }
    }
}
