using System;
using System.Linq;

namespace FuncsAndProcs
{
    class Program
    {
        static void Main(string[] args)
        {
            // Functions return something
            // type Name(type arg1, type arg2)   // arguments are special local variables. The can be assigned from the outside
            // {  
            //       ....
            //       return something_of_type
            // }
            var sum = Add( 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 );
            Console.WriteLine(sum);
            // Procedure return nothing
            // void Name(type arg1, type arg2)   // arguments are special local variables. The can be assigned from the outside
            // {  
            //       ....
            // }

            // nr = sum;
            // operetion:"value" is called named arguments
            ShowResult(sum, operation: "subtract");

            int a, b, c;
            FillForMe(out a, out b, out c);
            Console.WriteLine($"a={a}, b={b}, c={c}");
        }

        // Function
        static int Add(int a, int b)
        {
            int result = a + b;
            return result;
        }
        // params. ellipse in c/c++ 
        // Random number of integers
        static int Add(params int[] nrs)
        {
            int result = nrs.Sum();
            return result;
        }
        // An Overload.
        // Signature is determined by the name of the function, number of arguments and type of arguments
        // return type is not part of the signature!
        static double Add(double a, double b)
        {
            return a + b;
        }

        // The parameter 'operation' is an optional parameter.
        // You don't need to provide a value. It has a default value ('add')
        static void ShowResult(int nr, string operation = "add")
        {
            Console.WriteLine($"The result of {operation} is: {nr}");
        }
        static void ShowResult(double nr)
        {
            Console.WriteLine($"The result is: {nr}");
        }

        // Use argument references
        // Pass by Reference
        static void FillForMe(out int aaa, out int bbb, out int ccc)
        {
            aaa = 10;
            bbb = 20;
            ccc = 30;
        }

    }
}
