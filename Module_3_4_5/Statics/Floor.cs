using System;

namespace Statics
{
    public class Floor
    {
        public int Number { get; set; }
        // Static members are shared members
        // They don't belong a a specific instance. The are shared between all instances
        public static Elevator Lift { get; set; } = new Elevator();

        public void CallElevator()
        {
            // Number is an instance member. Need to be called on an instance, like 'this'
            // Lift is a class member. Doesn't belong to an instance. It belongs to all instances
            // this on a static member has no meaning.
            Floor.Lift.Call(this.Number);
        }
        public static void ShowElevatorStatus()
        {
            // In static methods you can call only other statics
            Console.WriteLine($"Elevator at {Lift.CurrentFloor}th");
        }

    }
}