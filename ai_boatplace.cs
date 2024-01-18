using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace battleboats
{
    internal class ai_boatplace
    {
        public static int[,] BoatPlacing(int[,] matrix)
        {
            for (int i = 0; i < 5; i++)
            {

                Random rnd = new Random();
                int[] Coordinates = { rnd.Next(8), rnd.Next(8) }; //generates random coordinates for the grid

                int direction = rnd.Next(5); // generates random direction for ship to face

                if (matrix[Coordinates[0], Coordinates[1]] == 1) // If coordiantes already have a ship, resets to last boat
                {
                    i = i - 1;
                }
                else if (direction == 1 && Coordinates[0] + 1 >= Boat_Types.Boat_Selection(i) && Checks.up(matrix, Coordinates, Boat_Types.Boat_Selection(i)))
                {   /// The above code uses the Check. series of functions to validate wether there is a ship in the way
                    matrix[Coordinates[0], Coordinates[1]] = 1;

                    for (int j = 0; j < Boat_Types.Boat_Selection(i); j++)
                    {
                        matrix[Coordinates[0] - j, Coordinates[1]] = 1;
                    }
                }
                else if (direction == 2 && Coordinates[1] >= Boat_Types.Boat_Selection(i))
                {/// The above code uses the Check. series of functions to validate wether there is a ship in the way
                    matrix[Coordinates[0], Coordinates[1]] = 1;

                    for (int j = 0; j < Boat_Types.Boat_Selection(i); j++)
                    {
                        matrix[Coordinates[0], Coordinates[1] - j] = 1;
                    }
                }
                else if (direction == 3 && matrix.GetLength(0) - Coordinates[0] >= Boat_Types.Boat_Selection(i) && Checks.down(matrix, Coordinates, Boat_Types.Boat_Selection(i)))
                {/// The above code uses the Check. series of functions to validate wether there is a ship in the way
                    matrix[Coordinates[0], Coordinates[1]] = 1;

                    for (int j = 0; j < Boat_Types.Boat_Selection(i); j++)
                    {
                        matrix[Coordinates[0] + j, Coordinates[1]] = 1;
                    }
                }
                else if (direction == 4 && matrix.GetLength(0) - Coordinates[1] >= Boat_Types.Boat_Selection(i))
                {/// The above code uses the Check. series of functions to validate wether there is a ship in the way
                    matrix[Coordinates[0], Coordinates[1]] = 1;

                    for (int j = 0; j < Boat_Types.Boat_Selection(i); j++)
                    {
                        matrix[Coordinates[0], Coordinates[1] + j] = 1;
                    }
                }
                else // if somehow all verification steps were failed, it just resets back to the beggining of the function
                {
                    matrix[Coordinates[0], Coordinates[1]] = 0;
                    i = i - 1;
                }

            }

            return matrix;
        }
    }
}
