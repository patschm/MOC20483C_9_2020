using System;
using System.Collections.Generic;
using System.Text;

namespace OldAttributes
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class)]
    public class MyAttribute : Attribute
    {
        public int Age { get; set; }
    }
}
