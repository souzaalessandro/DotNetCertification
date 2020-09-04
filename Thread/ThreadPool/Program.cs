using System;
using System.Threading;

namespace ThreadPoolApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Criar um pool de Thread para ser executado por uma fila.    

            ThreadPool.QueueUserWorkItem((s) =>
                {
                    Console.WriteLine("Working on a thread from threadpool");
                });
            Console.ReadLine();

        }

    }
}
