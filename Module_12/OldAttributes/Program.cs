using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OldAttributes
{
    class Program
    {
        static void Main(string[] args)
        {
            Person p = new Person { Name = "Henk", Age = 49 };
            DoSomething(p);

            Console.ReadLine();
        }

        private static void DoSomething(Person p)
        {
            var meth = p.GetType().GetMethod("Introduce");

            MyAttribute ma = meth.GetCustomAttributes(typeof(MyAttribute), false).First() as MyAttribute;

            if (ma.Age > 50)
            {
                Console.WriteLine("Nope");
            }
            else
            {
                p.Introduce();
            }
        }
    }
}
