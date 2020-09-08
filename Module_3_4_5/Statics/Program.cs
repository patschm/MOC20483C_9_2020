using System;

namespace Statics
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = "Patrick";
            name.MyOwnThing(42);

            "hello".MyOwnThing(67);

            Utils.DoSomething();

            Floor.ShowElevatorStatus();

            Floor[] highrise = new Floor[20];
            for (int i = 0; i < highrise.Length; i++)
            {
                highrise[i] = new Floor { Number = i };
            }

            highrise[12].CallElevator();

            foreach(Floor fl in highrise)
            {
                Floor.ShowElevatorStatus();
            }

        }
    }
}
