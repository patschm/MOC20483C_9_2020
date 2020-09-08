using System;

namespace Flows
{
    class Program
    {
        static void Main(string[] args)
        {
            int age = 20;

            // Jump forward (skip code)
            // if, else, else if
            // switch (case)

            // if (condition that evaluates to true or false)
            //{ true }
            // else
            // { .. }

            if (age >= 20)
            {
                Console.WriteLine("Oud genoeg");
                // if (...) Nesting is allowed
            }
            else
            {
                Console.WriteLine("Jonger");
            }

            switch(age)
            {
                case 10:
                    Console.WriteLine("Ten");
                    break;
                case 20:
                    Console.WriteLine("Twenty");
                    break;
                default:
                    Console.WriteLine("Else");
                    break;
            }

            // Jump back
            // for, while, do-while, foreach

            // for(statement 1; statement 2; statement 3)
            // { ... }
            // All statements are optionel
            // Statement 2 has restrictions. Must return true or false

            int x = 0;
            // Use for if you know how many times things must be repeated
            for (Console.WriteLine("Init"); x < 10; x++)
            {
                if (x == 5)
                {
                    break; // Ends loop
                    //continue; // Ends current iteration
                }
                //Console.WriteLine(x);
                
            }
            //Console.WriteLine(x);

            // Use while if you don't know how many times you have to repeat someting
            // And possibly doesnt' need to execute at all
            // Repeats 0 or more times
            // Commonly used for data tables, files etc.
            //while(x < 20)
            {
                //Console.WriteLine(x++);
            }

            // Use while if you don't know how many times you have to repeat someting
            // Repeats 1 of more times
            // Commonly used for user input
            //do
            {
                //Console.WriteLine(x);
            }
            //while (x < 30);

            // foreach
            // Can only be used on collections (collection must be an iterable)
            // Collection must implement the Iterator design pattern (Enumerable in .net)
            int[] nrs = { 1, 2, 3, 4 };
            foreach(int val in nrs)
            {
                Console.WriteLine(val);
            }

            Console.WriteLine("Normal flow");

        }
    }
}
