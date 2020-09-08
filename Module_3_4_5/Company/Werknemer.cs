using System;
using System.Collections.Generic;
using System.Text;

namespace Company
{
    abstract class Werknemer : Person, IContract
    {
        public abstract void DoWork();

        public void Execute()
        {
            DoWork();
        }
    }
}
