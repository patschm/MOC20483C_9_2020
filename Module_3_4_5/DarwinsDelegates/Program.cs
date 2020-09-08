using System;

namespace DarwinsDelegates
{
    delegate int MathDel(int a, int b);

    class Program
    {
        static void Main(string[] args)
        {
            // .NET 1.0/1.1
            MathDel m1 = new MathDel(Add);
            int result = m1(1, 2);

            // .NET 2.0
            MathDel m2 = Add;
            result = m2(2, 3);

            int c = 10;
            MathDel m3 = delegate(int a, int b)
            {
                return a + b;
            };
            result = m3(3, 4);

            // .NET 3.0 and beyond
            MathDel m4 = (a, b) => a + b;
            result = m4(4, 5);

            // Procedures
            // Can be used for procedurers with up to 16 arguments
            Action<string> m5 = (s) => Console.WriteLine("Hi " + s);
            m5("Patrick");

            // Functions
            // For function with up to 16 arguments
            // The last one betweer the brackets always represents the return type
            Func<int, int, int> m6 = Add;
            result = m6(7, 8);

            // Predicates
            // For functions that return a boolean
            //  Func<string bool> does the same
            Predicate<string> p1 = s => s == "hi";
            Console.WriteLine(p1("hi"));


            Console.WriteLine(result);
        }

        static int Add(int a, int b)
        {
            return a + b;
        }
    }
}
