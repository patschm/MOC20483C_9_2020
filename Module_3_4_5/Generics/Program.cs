using System;

namespace Generics
{
    class Program
    {
        class Point<W> where W: struct, IFormattable
        {
            public W X { get; set; }
            public W Y { get; set; }
        }

        static void Main(string[] args)
        {
            Point<int> p1 = new Point<int> { X = 2, Y = 5 };


            short a = 10;
            short b = 20;

            Console.WriteLine($"a={a}, b={b}");
            Swap(ref a, ref b);
            Console.WriteLine($"a={a}, b={b}");

        }

        private static void Swap<T>(ref T a, ref T b)
        {
            T tmp = b;
            b = a;
            a = tmp;
        }

        //private static void Swap(ref double a, ref double b)
        //{
        //    double tmp = b;
        //    b = a;
        //    a = tmp;
        //}
        //private static void Swap(ref long a, ref long b)
        //{
        //    long tmp = b;
        //    b = a;
        //    a = tmp;
        //}
        //private static void Swap(ref int a, ref int b)
        //{
        //    int tmp = b;
        //    b = a;
        //    a = tmp;
        //}
    }
}
