using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ParalellClass
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Parallel.For(0, 10, i =>{
                Console.WriteLine("Parallel For");
                Thread.Sleep(1000);
            });

            var numbers = Enumerable.Range(0,10);
            Parallel.ForEach(numbers, i =>{
                Console.WriteLine("Parallel ForEach");
                Thread.Sleep(1000);
                
            });


             ParallelLoopResult resultLoop = Parallel
             .For(0,10,(int i, ParallelLoopState loppState)=>{

                if (i==5)
                {
                    Console.WriteLine("Breaking loop");
                    loppState.Break();
                }
                return;
             });

            Console.WriteLine($"Resultado {resultLoop.ToString()}");

        }
    }
}
