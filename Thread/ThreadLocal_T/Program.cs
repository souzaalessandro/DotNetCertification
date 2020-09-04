using System;
using System.Threading;

namespace ThreadLocal_T
{
    public class Program
    {
        public static ThreadLocal<int> myPropertyManagement =
        new ThreadLocal<int>(() =>
        {
            return 10;
        });

        public static void Main(string[] args)
        {
          
            

            new Thread(()=>{
                
                for (int i = 0; i < myPropertyManagement.Value; i++)
                {
                    
                    Console.WriteLine("Thread A: {0}", i);
                    
                }
            }).Start();


            new Thread(()=>{
                
                for (int i = 0; i < myPropertyManagement.Value; i++)
                {
                    
                    Console.WriteLine("Thread B: {0}", i);
                    
                }
            }).Start();

            Console.ReadKey();
        }
    }
}
