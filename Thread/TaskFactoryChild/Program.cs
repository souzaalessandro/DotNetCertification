using System;
using System.Threading.Tasks;

namespace TaskFactoryChild
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //usamos o TaskFactory para criar Tasks filhas 
            Task<Int32[]> parent = Task.Run(()=>{
               var results = new Int32[3] ;

               var tf = new TaskFactory(TaskCreationOptions.AttachedToParent,TaskContinuationOptions.ExecuteSynchronously);

               tf.StartNew(()=> results[0] = 0);

               tf.StartNew(()=> results[1] = 1);

               tf.StartNew(()=> results[2] = 2);
               
               return results;

            });
            
            // vai aguardar a taskPai que por sua vez vai aguardar as tasks filhas
            var finalTask = parent.ContinueWith( parentTask => {
                    foreach(int i in parentTask.Result)
                        Console.WriteLine($"Result is {i}");
                });
            
            finalTask.Wait();



        }
    }
}
