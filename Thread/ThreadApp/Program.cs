using System;

using System.Threading;

namespace ThreadApp
{


    public static class Program
    {

        public static void ThreadingMethod()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("ThreadProc: {0}",i);
                Thread.Sleep(0);
            }
        }

        public static void Main(string[] args)
        {
            
            var t = new Thread( new ThreadStart(ThreadingMethod));
            t.Start();  // processamento paralelo
            for (int i = 0; i < 4; i++)
            {
                Console.WriteLine("Main thread: Do some work.");
                Thread.Sleep(0);
                
            }
            Console.WriteLine("Main thread: Call Join(), to wait until ThreadProc ends.");
            t.Join();
        }
    }
}
