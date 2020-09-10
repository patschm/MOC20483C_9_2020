using System;
using System.Threading.Tasks;

namespace IsolatedProblem
{
    class Program
    {
        static void Main(string[] args)
        {
            //Synchronous();
            AsynchronousOldStyle();

            Console.WriteLine("End Main Thread");
            Console.ReadLine();
        }

        private static void AsynchronousOldStyle()
        {
            Func<int, int, int> del = SpecialAdd;
            IAsyncResult ar = del.BeginInvoke(2, 3, null, null);


            //Console.WriteLine(res);
        }

        private static void Synchronous()
        {
            int res = SpecialAdd(3, 4);
            Console.WriteLine(res);
        }

        static int SpecialAdd(int a, int b)
        {
            Task.Delay(10000).Wait();
            return a + b;
        }
    }
}
