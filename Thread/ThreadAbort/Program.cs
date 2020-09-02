using System;
using System.Threading;
using System.Collections.Generic;

namespace ThreadAbort
{
    public static class Program
    {
        public static void ThreadingMethod(object o)
        {

            var listaParametros = (List<ParametroThread>)o;
            foreach (var parametro in listaParametros)
            {
                Console.WriteLine("ThreadProcName: {0}", parametro.PrintName);
                for (int i = 0; i < parametro.Quantidade; i++)
                {
                    Console.WriteLine("ThreadProc: {0}", i);
                    Thread.Sleep(0);
                }
            }
        }
        
        public static void Main(string[] args)
        {
            List<ParametroThread> listaParam = BuldParameter();
            var stopped = false;
            //Usar o ParameterizedThreadStart para enviar para a Thread os parametros do delegate
            var t = new Thread(new ThreadStart(()=> {
                
                while(!stopped)
                {
                    Console.WriteLine("Running");
                    Thread.Sleep(1000);
                }

            }));
            t.Start();
            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
            stopped = true;
            t.Join();
            
        }

        private static List<ParametroThread> BuldParameter()
        {
            return new List<ParametroThread>() {
                                    new ParametroThread(){
                                        PrintName = "Primeiro parametro",
                                        Quantidade = 3 },
                                    new ParametroThread(){
                                        PrintName = "Segundo parametro",
                                        Quantidade= 5}
                                };
        }
    }
}
