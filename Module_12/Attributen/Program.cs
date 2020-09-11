using System;

namespace Attributen
{
    class Program
    {
        static void Main(string[] args)
        {
            Person p = new Person { Name = "Henk", Age = 50 };
            DoSomething(p);
        }

        private static void DoSomething(Person p)
        {
            foreach(var attr in p.GetType().GetCustomAttributes(true))
            {
                Console.WriteLine(attr);
            }
            p.Introduce();
        }
    }
}
