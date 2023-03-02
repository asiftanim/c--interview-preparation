using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TaskProgramming
{
    internal class PausingTask
    {
        public static void Main()
        {
            var cts = new CancellationTokenSource();
            var token = cts.Token;

            var t = new Task(() =>
            {
                /*Thread.Sleep(1000); //suspund current thread
                Thread.SpinWait(1000); //make a thread wait, waste cpu resources
                SpinWait.SpinUntil((),1000); //make a thread wait, waste cpu resources. But if u need to wait little bit it is efficient than Thread.Sleep()*/
                Console.WriteLine("Press any key to disarm bomb. You have 5s!");
                bool cancelled = token.WaitHandle.WaitOne(5000);
                Console.WriteLine(cancelled ? "Bomb Disarmed" : "Boomm!!!");
            }, token);
            t.Start();

            Console.ReadKey();
            cts.Cancel();
            Console.WriteLine("Main method");
        }
    }
}
