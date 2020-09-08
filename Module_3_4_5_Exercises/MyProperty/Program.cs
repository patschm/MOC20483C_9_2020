using DoomsdayPreppers;
using Heras;
using Infrac;
using Philips;
using System;

namespace MyProperty
{
    class Program
    {
        static void Main(string[] args)
        {
            Detector detector = new Detector();
            Lamp tl = new Lamp();
            Gate gate = new Gate();
            Trap trap = new Trap();

            // Some connections
            detector.Connect(gate);
            detector.Connect(trap);
            detector.Connect(tl);
            detector.Detect();

        }
    }
}
