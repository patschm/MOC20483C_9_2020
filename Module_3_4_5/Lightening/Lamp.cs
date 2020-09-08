using System;
using System.Collections.Generic;
using System.Text;

namespace Lightening
{
    class Lamp
    {
        private uint lumen = 100;
        public uint Lumen
        {
            get { return lumen; }
            set
            {
                if (value <= 1000)
                {
                    lumen = value;
                }
            }
        }
        public ConsoleColor Color { get; set; } = ConsoleColor.Yellow;

        public void On()
        {
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = Color;
            Console.WriteLine($"Lamp is on and shines with {Lumen} lm");
        }
        public void Off()
        {
            Console.WriteLine("Lamp is off");
            Console.ResetColor();
            Console.ForegroundColor = Console.BackgroundColor;         
        }
    }
}
