using System;

namespace Statics
{
    public class Elevator
    {
        public int CurrentFloor;

        public void Call(int floor)
        {
            Console.WriteLine($"Elevator moves to {floor}th");
            CurrentFloor = floor;
        }
    }
}