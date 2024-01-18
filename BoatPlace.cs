using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace battleboats
{
    internal class BoatPlace
    {
        public static int[,] BoatPlacing(int[,] matrix) // This takes a blank matrix as input, and allows user to place their boats
        {
            
            Console.WriteLine("You get a submarines (2 tiles), 1 destroyer (2 tiles), 1 cruiser (3 tiles),");
            Console.WriteLine("1 battleship (4 tiles) and 1 carrier (5 tiles). \n");
            Console.WriteLine("To place a ship simply enter a set of coordinates and a direction for it to face.");
            Console.WriteLine("A grid showing where your ship is will be displayed.\n\n");

            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"Ship being placed is the {Boat_Types.Boat_Name(i)} \n\n");


                int[] Coordinates = Coord_Input.Coord_Inputing();// takes user input (coordinates) and validates it 
                

                Console.WriteLine("Enter a direction for the ship to face UP (1), LEFT (2), DOWN (3) or RIGHT (4).\n");
                // takes user input (direction) and validates it 
                var idek = Console.ReadLine();
                while (Checks.Invert(Checks.Int_Check(idek.ToCharArray())))
                {
                    Console.WriteLine("Invalid input, try again!");
                    idek = Console.ReadLine();
                }
                int direction = Convert.ToInt32(idek);
                

                if (matrix[Coordinates[0], Coordinates[1]] == 1) //checks if there is already a ship on coordinates picked, if so resets the player turn
                {
                    Console.WriteLine("Sorry you have already placed a ship starting at those coordinates.");
                    Console.WriteLine("Please try again! \n");
                    i = i - 1;
                }

                // The following code is a bit messy but it checks the user direction and applies the according verification
                // steps to make sure the boats dont overlap. It also puts the data in the matrix
                else if (direction == 1 && Coordinates[0] + 1 >= Boat_Types.Boat_Selection(i) && Checks.up(matrix,Coordinates,Boat_Types.Boat_Selection(i)))
                {
                    matrix[Coordinates[0], Coordinates[1]] = 1;

                    for (int j = 0; j < Boat_Types.Boat_Selection(i); j++)
                    {
                        matrix[Coordinates[0]-j, Coordinates[1]] = 1;
                    }

                    GridCreate.GridDisplay(matrix);
                }
                else if (direction == 2 && Coordinates[1] >= Boat_Types.Boat_Selection(i))
                {
                    matrix[Coordinates[0], Coordinates[1]] = 1;

                    for (int j = 0; j < Boat_Types.Boat_Selection(i); j++)
                    {
                        matrix[Coordinates[0], Coordinates[1]-j] = 1;
                    }

                    GridCreate.GridDisplay(matrix);
                }
                else if (direction == 3 && matrix.GetLength(0) - Coordinates[0] >= Boat_Types.Boat_Selection(i) && Checks.down(matrix, Coordinates, Boat_Types.Boat_Selection(i)))
                {
                    matrix[Coordinates[0], Coordinates[1]] = 1;

                    for (int j = 0; j < Boat_Types.Boat_Selection(i); j++)
                    {
                        matrix[Coordinates[0]+j, Coordinates[1]] = 1;
                    }

                    GridCreate.GridDisplay(matrix);
                }
                else if (direction == 4 && matrix.GetLength(0) - Coordinates[1] >= Boat_Types.Boat_Selection(i))
                {
                    matrix[Coordinates[0], Coordinates[1]] = 1;

                    for (int j = 0; j < Boat_Types.Boat_Selection(i); j++)
                    {
                        matrix[Coordinates[0], Coordinates[1] + j] = 1;
                    }

                    GridCreate.GridDisplay(matrix);
                }
                else // if somehow despite the input verification it gets to this it just resets the player turn
                {
                    Console.WriteLine("That Placement is not possible please try again.");
                    matrix[Coordinates[0], Coordinates[1]] = 0;
                    i = i - 1;
                }

            }

            return matrix;
        }
    }
}
