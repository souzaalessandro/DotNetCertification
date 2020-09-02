using System;
using System.Threading;

namespace ThreadAppBackGround
{
    public static class Program
    {
        public static void ThreadingMethod()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("ThreadProc: {0}", i);
                Thread.Sleep(1000);
            }
        }

        public static void Main(string[] args)
        {
            var t = new Thread(new ThreadStart(ThreadingMethod));
            t.IsBackground = true; // não espera a Thread terminar para fechar o programa.
            t.Start();  
        }
    }
}
