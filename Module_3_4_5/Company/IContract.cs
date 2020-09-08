using System;
using System.Collections.Generic;
using System.Text;

namespace Company
{
    // Inteface is a custom type!!!!
    // The type is used to decouple interaction between objects
    // You should ask the question 'can an object do something'? (can-do relation)
    interface IContract
    {
        // Only methods and properties allowed
        // No fields! An inteface has no state!!!!!
        // No Constructors. You cannot instantiate an interface
        // No access modifiers (public, private). Everything is by default public and stays public
        void Execute();
    }
}
