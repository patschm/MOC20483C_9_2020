using System;
using System.Diagnostics;

namespace Exceptions
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                DoSomething();
            }
            catch(Exception error)
            {
                Console.WriteLine("Ooops. Something went wrong");
                Console.WriteLine(error.Message);
                Console.WriteLine(error.HResult);
                Console.WriteLine(error.StackTrace);
                EventLog.WriteEntry("Application", "Ooops");
            }
        }

        static void DoSomething()
        {
            Console.WriteLine("Do Soemthing");
            SomethingElse();
        }

        static void SomethingElse()
        {
            do
            {
                Console.WriteLine("Give number");
                string sNr = Console.ReadLine();
                try
                {
                    int nr = int.Parse(sNr);
                    Console.WriteLine(nr);
                    return;
                }
                catch (FormatException fe)
                {
                    Console.WriteLine("Incorrect number");
                }
                catch (OverflowException oe)
                {
                    Console.WriteLine($"Number must be between {int.MinValue} and {int.MaxValue}");
                }
                finally
                {
                    // Will always be executer whether right or wrong
                    // Mainly used to free used resources
                    Console.WriteLine("Finally");
                }
                
            }
            while (true);
        }
    }
}
