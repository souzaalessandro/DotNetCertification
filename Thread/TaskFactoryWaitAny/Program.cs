using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace TaskFactoryWaitAny
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var tasks = new Task<int>[3];

            tasks[0] = Task.Run( () => { 
                    Thread.Sleep(2000);
                    return 10;
                 });
            
            tasks[1] = Task.Run( () => { 
                    Thread.Sleep(5000);
                    return 20;
                 });

            tasks[2] = Task.Run( () => { 
                    Thread.Sleep(2000);
                    return 30;
                 });                                  

            while (tasks.Length > 0)
            {
                var i = Task.WaitAny(tasks);

                Console.WriteLine($"Tasks Complete : {i}");    
                var completeTask = tasks[i];
                Console.WriteLine($"Tasks Result : {completeTask.Result}");    

                var temp = tasks.ToList();
                temp.RemoveAt(i);
                tasks = temp.ToArray();
                Console.WriteLine($"Tasks length : {tasks.Length}");


            }
        }
    }
}
