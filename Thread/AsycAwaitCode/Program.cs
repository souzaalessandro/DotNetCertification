using System;
using System.Threading;
using System.Threading.Tasks;

namespace AsycAwaitCode
{
    public class Program
    {
        public static void Main(string[] args)
        {
            
        }


        public Task SleeepAsyncA(int millisecondsTimeout)
        {
            return Task.Run(()=> Thread.Sleep(millisecondsTimeout));            
        }

        public Task SleepAsyncB(int millisecondsTimeout)
        {
            TaskCompletionSource<bool> tcs = null;
            var t = new Timer( delegate { tcs.TrySetResult(true);}, null, -1,-1);
            tcs = new TaskCompletionSource<bool>(t);
            t.Change(millisecondsTimeout,-1);
            return tcs.Task;
        }
    }
}
