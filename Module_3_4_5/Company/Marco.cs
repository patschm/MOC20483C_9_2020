using System;
using System.Collections.Generic;
using System.Text;

namespace Company
{
    class Marco : Werknemer
    {
        public override void DoWork()
        {
            Works();
        }
        public void Works()
        {
            Console.WriteLine("Marco works a lot!!!");
        }
    }
}
