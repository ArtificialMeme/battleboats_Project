using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;

namespace battleboats
{
    internal class Checks
    {
        public static bool down(int[,] matrix, int[] Coordinates, int Boat_Type)
        {
            int counter = 0;
            for (int i = 0; i < Boat_Type; i++)
            {
                if (matrix[Coordinates[0] + i, Coordinates[1]] == 0)
                {
                    counter += 1;
                }
            }
            if (counter == Boat_Type) { return true; }
            return false;
        }
        public static bool up(int[,] matrix, int[] Coordinates, int Boat_Type)
        {
            int counter = 0;
            for (int i = 0; i < Boat_Type; i++)
            {
                if (matrix[Coordinates[0] - i, Coordinates[1]] == 0)
                {
                    counter += 1;
                }
            }
            if (counter == Boat_Type) { return true; }
            return false;
        }
        public static bool right(int[,] matrix, int[] Coordinates, int Boat_Type)
        {
            int counter = 0;
            for (int i = 0; i < Boat_Type; i++)
            {
                if (matrix[Coordinates[0], Coordinates[1] + i] == 0)
                {
                    counter += 1;
                }
            }
            if (counter == Boat_Type) { return true; }
            return false;
        }
        public static bool left(int[,] matrix, int[] Coordinates, int Boat_Type)
        {
            int counter = 0;
            for (int i = 0; i < Boat_Type; i++)
            {
                if (matrix[Coordinates[0] + i, Coordinates[1] - i] == 0)
                {
                    counter += 1;
                }
            }
            if (counter == Boat_Type) { return true; }
            return false;
        }

        public static bool Hit_Check(int[,] matrix, int[] Coordinates)
        {
            if (matrix[Coordinates[0], Coordinates[1]] == 1)
            {
                Console.WriteLine("HIT!");

                return true;
            }

            return false;
        }
        public static int[,] Hit_Change(int[,] matrix, int[] Coordinates)
        {
            if (Hit_Check(matrix, Coordinates))
            {
                matrix[Coordinates[0], Coordinates[1]] = 2;
                return matrix;
            }
            return matrix;
        }

        public static bool Win_Check(int[,] matrix)
        {
            int counter = 0;
            for (int col = 0; col < matrix.GetLength(0); col++)
            {
                for (int row = 0; row < matrix.GetLength(0); row++)
                {
                    if (matrix[col,row] == 2)
                    {
                        counter++;
                    }
                }
            }
            if (counter == 16)
            {
                return true;
            }
            return false;
        }
        public static bool Invert(bool boolean)
        {
            if (boolean == true)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public static bool Int_Check(char[] sss)
        {
            if (sss.Count() < 1)
            {
                return false;
            }
            if (sss[0] == '1' || sss[0] == '2' || sss[0] == '3' || sss[0] == '4')
            {
                return true;
            }

            return false;
        }
    }
}
