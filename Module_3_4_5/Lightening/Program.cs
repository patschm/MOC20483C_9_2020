using System;

namespace Lightening
{
    class Program
    {
        static void Main(string[] args)
        {
            Lamp l1 = new Lamp { Color = ConsoleColor.Red, Lumen = 4000 };
            l1.On();
            Console.WriteLine("Hello World");
            l1.Off();
            Console.WriteLine("Hello Darkness");
        }
    }
}
