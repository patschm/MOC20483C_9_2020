using System;

namespace Structures
{
    // All classes are reference types.
    // When you make a copy of a reference type variable. you copy an address (where the actual value is storerd)
    // All structs are value types
    // When you make a copy of a value type, you copy the content of that variable
    struct Point
    {
        public int X { get; set; }
        public int Y { get; set; }

        public override string ToString()
        {
            return $"({X}, {Y})";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Point p1 = new Point { X = 100, Y = 200 };
            Console.WriteLine(p1);
            DoSomething(p1);
            Console.WriteLine(p1);
        }

        private static void DoSomething(Point px)
        {
            px.X = 1000;
            px.Y = 2000;
        }
    }
}
