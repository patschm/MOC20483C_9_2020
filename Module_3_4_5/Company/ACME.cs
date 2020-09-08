using System;
using System.Collections.Generic;
using System.Text;

namespace Company
{
    class ACME
    {

        public IContract werknemer;

        public void Start()
        {
            Console.WriteLine("ACME starts producing stuff");
            werknemer?.Execute();
        }
    }
}
