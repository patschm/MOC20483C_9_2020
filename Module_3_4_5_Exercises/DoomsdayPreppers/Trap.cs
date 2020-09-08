using Standards;
using System;

namespace DoomsdayPreppers
{
    public class Trap: IDetectable
    {
        public void Detect()
        {
            Open();
        }

        public void Open()
        {
            Console.WriteLine("The trap opens");
        }
    }
}
