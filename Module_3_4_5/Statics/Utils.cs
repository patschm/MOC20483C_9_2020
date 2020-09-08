using System;
using System.Collections.Generic;
using System.Text;

namespace Statics
{
    static class Utils
    {
        // This is an extension method.
        // A handy trick to extend class definitions which you don't have
        public static void MyOwnThing(this string s, int nr)
        {
            Console.WriteLine($"My own {s} {nr}");
        }

        public static void DoSomething()
        {
            Console.WriteLine("Does something");
        }
    }
}
