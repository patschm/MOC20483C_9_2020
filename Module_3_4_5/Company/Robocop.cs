using System;
using System.Collections.Generic;
using System.Text;

namespace Company
{
    // Robocop IMPLEMENTS (NOT INHERITS!) the inteface IContract
    // You can implement multiple interfaces
    class Robocop : IContract, IContract2
    {
        public void Execute()
        {
            Console.WriteLine("Robocop works");
        }

        // Explicit implmentation
        // Only needed in case of a collision between methods of multiple interfaces
        void IContract2.Execute()
        {
            Console.WriteLine("Robocop kick ass");
        }
    }
}
