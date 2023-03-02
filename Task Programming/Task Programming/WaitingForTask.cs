using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TaskProgramming
{
    internal class WaitingForTask
    {
        public static void Main()
        {
            var cts = new CancellationTokenSource();
            var token = cts.Token;

            var t1 = new Task(() =>
            {
                //Console.WriteLine("I take 5 seconds!");
                for(int i=0; i<5; i++)
                {
                    token.ThrowIfCancellationRequested();
                    Thread.Sleep(1000);
                }

                Console.WriteLine("T1 done");
            }, token);
            t1.Start();

            Task t2 = Task.Factory.StartNew(() =>
            {
                Thread.Sleep(3000);
                Console.WriteLine("T2 done.");
            }, token);

            //Task.WaitAll(t1, t2); //wait for all task to complete
            //Task.WaitAny(t1, t2); //wait for any task to complete

            //Console.ReadKey();
            //cts.Cancel();

            Task.WaitAll(new[] {t1, t2}, 5001, token); //wait for all task to complete. Maximum wait 4000ms. token to know cancelation. If the token is canceled it will throw exception
            Console.WriteLine($"Task t1 status is {t1.Status}");
            Console.WriteLine($"Task t2 status is {t2.Status}");
            //Task.WaitAll(t); //takes array of Task[] to wait
            //t1.Wait(token);

            Console.WriteLine("Main method");
        }
    }
}
