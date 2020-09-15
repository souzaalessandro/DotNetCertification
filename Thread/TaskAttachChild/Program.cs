using System;
using System.Threading.Tasks;

namespace TaskAttachChild
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Task<Int32[]> parent = Task.Run(()=> 
            {
                var results = new Int32[3];
                new Task(()=> results[0] =0, TaskCreationOptions.AttachedToParent).Start();

                new Task(()=> results[1] =1, TaskCreationOptions.AttachedToParent).Start();

                new Task(()=> results[2] =2, TaskCreationOptions.AttachedToParent).Start();

                // vai aguardar a finalização que cada thread filha para finalizar o processo
                return results;

            });

            //vai aguardar o finalização de todo o processo antes de executar algo
            // o processo acontece em cascata , esse aguarda o pai e aguarda os filhos
            var finalTask = parent.ContinueWith( parentTask => {
                foreach(int i in parentTask.Result)
                    Console.WriteLine($"Result is {i}");
                });

            finalTask.Wait();
        }
    }
}
