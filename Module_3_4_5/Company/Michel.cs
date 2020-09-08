using System;
using System.Collections.Generic;
using System.Text;

namespace Company
{
    class Michel : Werknemer
    {
        public void DoSomething()
        {
            Console.WriteLine("Michel does something");
        }

        public override void DoWork()
        {
            DoSomething();
        }
    }
}
