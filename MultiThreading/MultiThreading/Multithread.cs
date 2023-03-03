using System;
using System.Threading;

namespace Multithread
{
    public static class Multithread
    {
        public static void CountDown(string name)
        {

            for (int i = 10; i > 0; i--)
            {
                Console.WriteLine($"{name} #1 : {i} seconds" );
                Thread.Sleep(1000);
            }
            Console.WriteLine($"Timer #1 is complete");
        }

        public static void CountUp(string name)
        {

            for(int i=0; i<10; i++)
            {
                Console.WriteLine($"{name} #2 : {i} seconds");
                Thread.Sleep(1000);
            }
            Console.WriteLine($"Timer #2 is complete");
        }

        public static void Main()
        {
            Thread mainThread = Thread.CurrentThread;
            mainThread.Name = "main thread";
            Console.WriteLine(mainThread.Name);

            Thread thread1 = new Thread(() => CountDown("asif down"));
            thread1.Start();

            Thread thread2 = new Thread(() => CountUp("asif up"));
            thread2.Start();
            

            Console.WriteLine($"{mainThread.Name} is complete");

            Console.ReadKey();
        }
    }
}