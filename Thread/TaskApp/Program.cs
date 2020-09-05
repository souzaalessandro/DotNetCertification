using System;
using System.Threading.Tasks;

namespace TaskApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var t = Task.Run(()=> {

                for (int i = 0; i < 10000; i++)
                {
                    Console.WriteLine("*");
                }

            });
            // usamos o wait para aguardar rodar a thread antes de finalizar a aplicação
            t.Wait();
        }
    }
}
