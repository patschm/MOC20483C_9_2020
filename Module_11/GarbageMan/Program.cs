using System;

namespace GarbageMan
{
    class Program
    {
        static void Main(string[] args)
        {
            UMan m1 = new UMan();
            try
            {
                m1.Open();
            }
            finally
            {
                m1.Dispose();
            }
            m1 = null;

            //GC.Collect();
            //GC.WaitForPendingFinalizers();

            using (UMan m2 = new UMan())
            {
                m2.Open();
            }

            Console.ReadLine();
        }
    }
}
