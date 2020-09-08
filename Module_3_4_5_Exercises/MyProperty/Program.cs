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
            //detector.Connect(gate);
            //detector.Connect(trap);
            //detector.Connect(tl);

            //detector.Connect(gate.Open);
            //detector.Connect(trap.Open);
            //detector.Connect(tl.On);

            detector.Actions += gate.Open;
            detector.Actions += trap.Open;
            detector.Actions += tl.On;


            detector.Detect();

        }
    }
}
