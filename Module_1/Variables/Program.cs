using System;
using System.Collections.Generic;

namespace Variables
{
    class Program
    {
        static void Main(string[] args)
        {
            // Strong typed
            // **********************
            // DataType varname;
            // **********************
            // All variables need to be initialized
            string name ="Patrick";
            int age = 18;

            // Expression
            // Involves at least one operator and one to three operands (variable or literal)

            Console.WriteLine(name?.Length);
            bool isTrue = name is string;
            Console.WriteLine(isTrue);

            byte tiny = (byte)age;  // age as byte

            age += 4; // age = age + 4

            //int year = null; // Can't do
            int? years = 67; // Is ok. years is a nullable type

            int result = years ?? 42;
            Console.WriteLine(result);

            List<int> numbers = new List<int>();
            //(numbers ??= new List<int>()).Add(4)
            Console.WriteLine(name);
            Console.WriteLine(nameof(name));


            // Scope variables
            // Determined by { }
            {
                int x = 20;
                Console.WriteLine(x);
            }
            //Console.WriteLine(x); // Can't do. x is gone (})
        }
    }
}
