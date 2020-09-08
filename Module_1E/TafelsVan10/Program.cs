using System;

namespace TafelsVan10
{
    class Program
    {
        static void Main(string[] args)
        {
            // 1 x 1 = 1
            // 2 x 2 = 2
            // 3 x 1= 3
            // ...
            // 10 x 1 = 10
            //..
            //..
            // 1 x 10 = 10
            //...
            // 10 x 10 = 100

            for (int table = 1; table <= 10; table++)
            {
                Console.WriteLine($"table of {table}");
                for (int counter = 1; counter <= 10; counter++)
                {
                    //Console.WriteLine(counter + " x " + table + " = " + counter * table);
                    Console.WriteLine("{0, -2} x {1, -2} = {2}", counter, table, counter * table);
                    Console.WriteLine($"{counter, -2} x {table, -2} = {counter * table}");
                }
            }

            Console.WriteLine();

        }
    }
}
