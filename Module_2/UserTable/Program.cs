using System;

namespace UserTable
{
    class Program
    {
        static void Main(string[] args)
        {
            WelcomeUser();
            do
            {
                int table = AskForTable();
                ShowTable(table);
            }
            while (AskContinuation());
            GoodbyeScreen();
        }

        static void GoodbyeScreen()
        {
            Console.WriteLine("Bye bye *sniff*");
        }

        static void ShowTable(int table)
        {
            Console.Clear();
            for (int counter = 1; counter <= 10; counter++)
            {
                Console.WriteLine($"{counter} x {table} = {counter * table}");
            }
        }

        static bool AskContinuation()
        {
            Console.WriteLine("Another table? (y/n)");
            string choice = Console.ReadLine();
            return choice.ToLower().StartsWith("y");

        }

        static int AskForTable()
        {
            do
            {
                Console.WriteLine("What table do you want to see?");
                string sNr = Console.ReadLine();
                try
                {
                    return int.Parse(sNr);
                }
                catch(FormatException fe)
                {
                    Console.WriteLine("Wrong input. Try again");
                }
            }
            while (true);

        }

        static void WelcomeUser()
        {
            Console.WriteLine("Howdy user :)");
        }
    }
}
