using System;
using System.Threading;
using System.Collections.Generic;

namespace ThreadParametrizedStart
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
            var listaParam = new List<ParametroThread>() {
                                    new ParametroThread(){
                                        PrintName = "Primeiro parametro",
                                        Quantidade = 3 }, 
                                    new ParametroThread(){
                                        PrintName = "Segundo parametro",
                                        Quantidade= 5}
                                };
            //Usar o ParameterizedThreadStart para enviar para a Thread os parametros do delegate



            var t = new Thread(new ParameterizedThreadStart(ThreadingMethod));
            t.Start(listaParam);
            t.Join(); 
        }
    }
}
