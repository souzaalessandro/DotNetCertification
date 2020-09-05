using System;
using System.Threading.Tasks;

namespace TaskAppByType
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Task<int> t = Task.Run(()=>{
                return 150;
            });    

            Console.WriteLine(t.Result);
        }
    }
}
