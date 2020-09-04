using System;
using System.Threading;

namespace ThreadPoolQueueApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            const int FibonacciCalculations = 5;
            var doneEvents = new ManualResetEvent[FibonacciCalculations];
            var fibArray = new Fibonacci[FibonacciCalculations];

            var rand = new Random();

            Console.WriteLine($"Lauching {FibonacciCalculations} tasks ...");

            for (int i = 0; i <FibonacciCalculations; i++)
            {
                doneEvents[i] = new ManualResetEvent(false);
                var f = new Fibonacci(rand.Next(20,40), doneEvents[i]);
                fibArray[i]= f;
                ThreadPool.QueueUserWorkItem(f.ThreadPollCallback,i);
            }

            WaitHandle.WaitAll(doneEvents);
            Console.WriteLine("All calculations are complete");

            for (int i = 0; i <FibonacciCalculations; i++)
            {
                Fibonacci f = fibArray[i];
                Console.WriteLine($"Fibonacci {f.N} = {f.FibOfn}");
            }


        }
    }
}
