using Standards;
using System;

namespace Heras
{
    public class Gate : IDetectable
    {
        public void Detect()
        {
            Open();
        }

        public void Open()
        {
            Console.WriteLine("The gate opens");
        }
    }
}
