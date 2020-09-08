using System;
using System.Collections.Generic;
using System.Text;

namespace FunctionPong
{
    // Keep in mind that delegate is just another data type (like interface, class, enum)
    // A delegate is a blueprint if a function
    // Which means you have to specify its arguments and return type
    delegate int MyOp(int x, int y);

    class Calculator
    {
        public void Calculate(MyOp oper)
        {
            Console.WriteLine("Calculator...");
            // Calculate
            int res = oper(4, 5);
            Console.WriteLine(res);

            // Show Result
        }
    }
}
