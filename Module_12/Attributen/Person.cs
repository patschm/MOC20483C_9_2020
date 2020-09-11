using System;
using System.Runtime.InteropServices;

namespace Attributen
{
    //[Obsolete("Niet meer gebruiken", true)]
    
    public class Person
    {
        //[FieldOffset(4)]
        private int age;
        public int Age
        {
            get { return age; }
            set
            {
                if (value >= 0 && value < 130)
                {
                    age = value;
                }
            }
        }
        public string Name { get; set; }

        [My(Age = 42)]
        public void Introduce()
        {
            Console.WriteLine($"Hello I'm {Name} and {Age} year(s) old");
        }
    }
}
