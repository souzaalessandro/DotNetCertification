using System;
using System.Threading.Tasks;

namespace TaskAppContinusTask
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var t = Task.Run(()=>{
                Console.WriteLine("Step 1");
                return 150;    
            }).ContinueWith((i)=> {

                Console.WriteLine("Step 2");
                return i.Result * 2;
            });
            Console.WriteLine($"Task value {t.Result}");

            var t2 = Task.Run(()=> {

                return 48;
            });

            t2.ContinueWith((i)=> {
                Console.WriteLine("Canceled");
            }, TaskContinuationOptions.OnlyOnCanceled);

            t2.ContinueWith((i)=> {
                Console.WriteLine("Faulted");
            }, TaskContinuationOptions.OnlyOnFaulted);

            t2.ContinueWith((i)=> {
                Console.WriteLine("Completed");
            }, TaskContinuationOptions.OnlyOnRanToCompletion);



        }
    }
}
