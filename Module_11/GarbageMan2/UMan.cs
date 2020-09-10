using System;
using System.Collections.Generic;
using System.Text;

namespace GarbageMan2
{
    public class UMan
    {
        private static bool isOpen = false;
        public void Open()
        {
            if (!isOpen)
            {
                Console.WriteLine("Opening...");
                isOpen = true;
            }
            else
            {
                Console.WriteLine("Too bad. Already in use");
            }
        }
        public void Close()
        {
            Console.WriteLine("Closing...");
            isOpen = false;
        }

        ~UMan()
        {
            Close();
        }
    }
}
