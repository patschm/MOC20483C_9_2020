using System;

namespace Objects
{
    class Program
    {
        static void Main(string[] args)
        {
            // p1 is an object!
            Pen p1 = new Marker();
            p1.Write("Hello");

            Pen p2 = new Marker();
            p2.Color = ConsoleColor.Green;
            p2.LineWidth = 10;
            p2.Write("World");
            Console.WriteLine(p2.LineWidth);

            Pen p3 = new Marker { Color = ConsoleColor.Blue, LineWidth = 20, IsRemovable = false };
            // With generalization you lose track of specific characteristics
            // They are not gone however.
            Console.WriteLine(((Marker)p3).IsRemovable);
            p3.Write("Nice!!");
        }
    }

    // Class is a blueprint of an object
    // Make a class abstract if you don't allow users to make instances of it.
    // Happens when there's at least one abstract method
    abstract class Pen
    {
        // Properties of an object are stored in fields
        //private ConsoleColor color = ConsoleColor.Red;
        private int lineWidth = 2; // Encapsulation. Private members only accessible through access methods

        // Access Methods C++/Java etc way
        // Don't do it like this. Looks like poor self study
        public int GetLineWidth()
        {
            return lineWidth;
        }
        public void SetLineWidth(int lw)
        {
            if (lw > 0 && lw <= 40)
            {
                lineWidth = lw;
            }
            else
            {
                Console.WriteLine("Impossible");
            }
        }

        // Properties. The dotnet way to control access to private members
        // This is how a C# developer does it!!!
        public int LineWidth
        {
            get
            {
                return lineWidth;
            }
            set 
            {
                if (value > 0 && value <= 40)
                {
                    lineWidth = value;
                }
                else
                {
                    Console.WriteLine("Impossible");
                }
            }
        }
        // Auto generating property
        // It generates its own fields which is so private that even you can't access it
        public ConsoleColor Color { get; set; } = ConsoleColor.Red;

        // Behavior are described in methods
        // Virtual makes this method polymorph-ready
        // Derived classes can override this method if they want. (it's not mandatory)
        // You can force classes to override this method by using abstract instead of virtual

        public abstract void Write(string someText);
        //public virtual void Write(string someText)
        //{
        //    Console.ForegroundColor = Color;
        //    Console.WriteLine($"{someText} in linewidth {LineWidth}");
        //    Console.ResetColor();
        //}

        // Constructor
        // To initialize fields!!
        // This is the default constructor. Automatically generated if you don't 
        // make your own constructors
        public Pen()
        {

        }

        // Making your own removes the default constructor
        public Pen(int lnw, ConsoleColor color)
        {
            LineWidth = lnw;
            this.Color = color;
        }
    }

    // Inheritance. Derive existing properties and behavior from a base class
    // In this case Pen (:)
    // You can derive from only one (1) class!
    // I can however derive from Marker
    // Benefit 1: Inheritance enforces reuseability
    // Benefit 2: The ability to generalize
    // Only use if talk about an is-a relation
    // Ask yourself the question: Is it an?
    // Sealed. You cannot inherit from Marker anymore
    sealed class Marker : Pen
    {
        public bool IsRemovable { get; set; } = true;

        public void Erase()
        {
            Console.Clear();
        }
        // Enable Polymorphism by using the override keyword.
        // Polymorphism is the ability to _generalize_ without losing specific _behavior_
        public  override void Write(string someText)
        {
            Console.ForegroundColor = Color;
            Console.WriteLine($"Marker writes: {someText} in linewidth {LineWidth}");
            Console.ResetColor();
        }

    }
}
