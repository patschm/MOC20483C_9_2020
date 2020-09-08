using System;

namespace Array
{
    class Program
    {
        static void Main(string[] args)
        {
            // Array is a collection with similar elements
            // Are immutable (cannot change in size)
            // Continuous block of memory
            // datatype[] varname;
            // Arrays are zero-based!!! (starts with 0)
            int[] numbers = new int[5];
            // access elements by using [] operator
            numbers[1] = 2;
            int res = numbers[1];

            int[] nrs2 = { 1, 2, 3, 4, 5, 6 };

            int[,] matrix = new int[2, 3];
            int[,,] cube = new int[3, 3, 3];

            matrix[1, 2] = 4;

            // Special one
            // Jagged array. Array with array members
            int[][] jagged = new int[3][];
            jagged[0] = new int[] { 1, 2, 3 };
            jagged[1] = new int[] { 1, 2, 3, 4,5, 6 };
            jagged[2] = new int[] { 1, 2, 3, 4, 5 };

            Console.WriteLine(jagged[2][3]);



        }
    }
}
