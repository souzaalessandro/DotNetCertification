using System;
using System.Threading;

namespace ThreadStaticAtribute
{
    public class Program
    {

        [ThreadStatic]
        public static int myProperty;
        public static void Main(string[] args)
        {

            new Thread(()=>{
                
                for (int i = 0; i < 10; i++)
                {
                    myProperty++;
                    Console.WriteLine("Thread A: {0}", myProperty);
                    
                }
            }).Start();


            new Thread(()=>{
                
                for (int i = 0; i < 10; i++)
                {
                    myProperty++;
                    Console.WriteLine("Thread B: {0}", myProperty);
                    
                }
            }).Start();

            Console.ReadKey();
        }
    }
}
