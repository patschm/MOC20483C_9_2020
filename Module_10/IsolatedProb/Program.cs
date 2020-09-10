using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsolatedProb
{
    class Program
    {
        static async Task Main(string[] args)
        {
            //Synchronous();
            //AsynchronousOldStyle();
            AsynchronousModern();

            Console.WriteLine("End Main Thread");
            Console.ReadLine();
        }

        private static async Task AsynchronousModern()
        {
            //Task<int> t1 = new Task<int>(() => SpecialAdd(5, 6));
            //t1.Start();

            //Task<int> t1 = Task.Run<int>(() => SpecialAdd(7, 8));
            //int res = await t1;  // return;

            int res = await SpecialAddAsync(9, 10);
            Console.WriteLine("Ah. Task is ready. Now we continue with this function");
            Console.WriteLine(res);
        }

        private static void AsynchronousOldStyle()
        {
            Func<int, int, int> del = SpecialAdd;
            IAsyncResult ar = del.BeginInvoke(2, 3, ares=> {
                int res = del.EndInvoke(ares);
                Console.WriteLine(res);
            }, null);


            //while(!ar.iscompleted)
            //{
            //    console.write(".");
            //    task.delay(100).wait();
            //}           
        }

        private static void Synchronous()
        {
            int res = SpecialAdd(3, 4);
            Console.WriteLine(res);
        }

        static int SpecialAdd(int a, int b)
        {
            Task.Delay(5000).Wait();
            return a + b;
        }
        static  Task<int> SpecialAddAsync(int a, int b)
        {
            return Task.Run<int>(() => SpecialAdd(a, b));
        }
    }
}
