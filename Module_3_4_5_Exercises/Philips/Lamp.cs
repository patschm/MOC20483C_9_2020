using Standards;
using System;

namespace Philips
{
    public class Lamp : Device, IDetectable
    {
        public void Detect()
        {
            On();
        }

        public void On()
        {
            Console.WriteLine("The lamp goes on");
        }
    }
}
