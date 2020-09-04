using System;
using System.Threading;

namespace ThreadPoolQueueApp
{
    public class Fibonacci
    {
        private ManualResetEvent _dotNetEvent;

        public Fibonacci(int n, ManualResetEvent doneEvent)
        {
            N=n;
            _dotNetEvent = doneEvent;
        }

        public int N { get; }  
        public int FibOfn { get; private set; }

        public void ThreadPollCallback(Object threadContext)
        {
            int threadIndex = (int)threadContext;
            Console.WriteLine($"Thread {threadIndex} started...");
            FibOfn = Calculate(N);

        }

        public int Calculate( int n )
        {
            if (n <=1)
            {
                return n;
            }

            return Calculate(n-1) + Calculate(n-2);
        }


    }
}