﻿using System;
using System.Threading;
using System.Threading.Tasks;

namespace TaskFactoryWaitAll
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Task[] tasks = new Task[3];

            tasks[0] = Task.Run( () => { 
                    Thread.Sleep(1000);
                    Console.WriteLine("1");
                    return 1;
                 });
            
            tasks[1] = Task.Run( () => { 
                    Thread.Sleep(5000);
                    Console.WriteLine("2");
                    return 1;
                 });

            tasks[2] = Task.Run( () => { 
                    Thread.Sleep(1000);
                    Console.WriteLine("3");
                    return 1;
                 });                                  

            Task.WaitAll(tasks);

        }
    }
}
