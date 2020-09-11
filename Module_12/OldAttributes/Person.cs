using System;
using System.Runtime.InteropServices;

namespace OldAttributes
{
    //[Obsolete("Niet meer gebruiken", false)]
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

        [My(Age = 52)]
        public void Introduce()
        {
            Console.WriteLine($"Hello I'm {Name} and {Age} year(s) old");
        }
    }
}
