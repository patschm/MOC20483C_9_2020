using System;

namespace Enums
{
    // 00001101 state of robot arm
    // 00001101 & 00000100

    // Enums are used to give a meaning to a number
    enum Weekdays : long
    {
        Sunday = 1,
        Monday = 2,
        Tuesday = 4,
        Wednesday = 8,
        Thursday = 16,
        Friday = 32,
        Saturday = 64
    }

    class Program
    {
        static void Main(string[] args)
        {
            int weekday = 2;
            Weekdays wd = Weekdays.Tuesday;

            Console.WriteLine((Weekdays)weekday);
            Console.WriteLine(wd);
        }
    }
}
