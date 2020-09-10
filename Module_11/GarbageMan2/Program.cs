using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarbageMan2
{
    class Program
    {
        static void Main(string[] args)
        {
            {
                UMan m1 = new UMan();
                m1.Open();
            }

            GC.Collect();
            GC.WaitForPendingFinalizers();
            
            UMan m2 = new UMan();
            m2.Open();


            Console.ReadLine();
        }
    }
}
