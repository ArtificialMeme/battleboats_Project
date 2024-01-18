using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace battleboats
{
    internal class GridCreate
    {
        public static int[,] GridCreation()// Creates the blank 8x8 grid used everywhere
        {
            int[,] matrix = new int[8, 8];

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    matrix[i,j] = 0;
                }
            }

            return matrix;
        }
        public static int[,,] GridCreation2() // creates a 8x8x4 3D array that I dont actually need anymore so idk why
        {                                     // this is still here
            int[,,] matrix = new int[8, 8, 4];

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    for (int k = 0; k < 4; k++)
                    {
                        matrix[i, j, k] = 0;
                    }
                }
            }

            return matrix;

        }

        public static void GridDisplay(int[,] matrix) // Displays the 8x8 grid in a nice human friendly way
        {
            int rowLength = matrix.GetLength(0);
            int colLength = matrix.GetLength(1);

            for (int i = 0; i < rowLength; i++)
            {
                for (int j = 0; j < colLength; j++)
                {
                    Console.Write(string.Format("{0} ", matrix[i, j]));
                }
                Console.Write(Environment.NewLine);
            }
        }
    }
}
