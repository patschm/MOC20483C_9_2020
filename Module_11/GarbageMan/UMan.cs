using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace GarbageMan
{
    // Dispose Pattern
    public class UMan : IDisposable
    {
        private FileStream fs = null;
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

        // Implement both IDispoable and Finalizer (destructor)
        public void Dispose()
        {
            // Only here you dispose unmanaged members
            fs?.Dispose();
            Close();
            GC.SuppressFinalize(this);
        }

        ~UMan()
        {
            // Don't dispose unmanaged members here
            Close();
        }
    }
}
