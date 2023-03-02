using System;
using System.Threading;
using System.Threading.Tasks;

namespace TaskProgramming
{
    internal class CancellingTask
    {
        public static void Main()
        {
            //Task Cancelation
            /*CancellationTokenSource cts = new CancellationTokenSource();
            var Token = cts.Token;

            Token.Register(() =>
            {
                Console.WriteLine("Cancellation has been requested");
            });

            var t = new Task(() =>
            {
                int i = 0;
                while (true)
                {
                    //know as soft exit from a Task
                    *//*if (Token.IsCancellationRequested)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine($"{i++}\t");
                    }*//*

                    //Throw exception while calcellation requested
                    *//*if (Token.IsCancellationRequested)
                    {
                        throw new OperationCanceledException();
                    }
                    else
                    {
                        Console.WriteLine($"{i++}\t");
                    }*//*

                    //Shortcut of previous block of codes
                    Token.ThrowIfCancellationRequested();
                    Console.WriteLine($"{i++}\t");

                }
            }, Token);
            t.Start();

            Task.Factory.StartNew(() =>
            {
                Token.WaitHandle.WaitOne();
                Console.WriteLine("wait handle has been released, cancellation was requested");
            });


            Console.ReadKey();
            cts.Cancel();*/

            //Composite Calcellation
            var planned = new CancellationTokenSource();
            var preventative = new CancellationTokenSource();
            var emergency = new CancellationTokenSource();

            //combine all 3 tokens into 1. Cancellation request from any token will trigger paranoid as cancel.
            var paranoid = CancellationTokenSource.CreateLinkedTokenSource(planned.Token, preventative.Token, emergency.Token);

            Task.Factory.StartNew(() =>
            {
                int i = 0;
                while (true)
                {
                    paranoid.Token.ThrowIfCancellationRequested();
                    Console.WriteLine($"{i++}\t");
                    Thread.Sleep( 1000 );
                }
            }, paranoid.Token);

            Console.ReadKey();
            emergency.Cancel(); //will trigger paranoid cancel

            Console.WriteLine("Main method");
        }
    }
}
