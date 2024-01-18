using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace battleboats
{
    internal class Game
    {
        public static bool New_game()
        {
            // player instructions
            Console.WriteLine("Hello captains! Our first order of buisness is for you both to pick your");
            Console.WriteLine("starting ship positions! Choose who would be P1 and P2. P1 starts first.");

            int[,] P1_board = BoatPlace.BoatPlacing(GridCreate.GridCreation()); //p1 places boats usign function
            int[,] P1_HitBoard = GridCreate.GridCreation();

            Console.WriteLine("Now its time for P2.");

            int[,] P2_board = BoatPlace.BoatPlacing(GridCreate.GridCreation()); //p2 places boats using function
            int[,] P2_HitBoard = GridCreate.GridCreation();

            bool temp = false;

            Console.WriteLine("Now that you both have your boards ready, we can begin!");


            while ((Checks.Invert(Checks.Win_Check(P1_board)) && Checks.Invert(Checks.Win_Check(P2_board))) || temp)
            { //above code checks for winner

                for (int i = 0; i <= 1; i++)
                {
                    if (Checks.Win_Check(P1_board) || (Checks.Win_Check(P2_board)))// checks for winner at this level as well
                    {
                        break;//breaks out of loop if there is a winner to the function can end
                    }
                    bool p_turn = true;//resets the end of turn temp bool
                    while (p_turn)
                    {
                        //instruction for players x2
                        Console.WriteLine($"This is the start of Player{i + 1}'s turn.");
                        Console.WriteLine("Your options are:");
                        Console.WriteLine("1. Display your own hit checking grid.");
                        Console.WriteLine("2. Display your own ship grid.");
                        Console.WriteLine("3. Attempt to shoot at the enemy! (this ends your turn)\n\n");

                        int choice = Convert.ToInt32(Console.ReadLine());
                        if (Checks.Win_Check(P1_board) || (Checks.Win_Check(P2_board) || temp))
                        {
                            break;
                        }

                        if (i == 0)
                        {
                            if (choice == 1) { GridCreate.GridDisplay(P1_HitBoard); }// If player input is 1 do what the code says

                            else if (choice == 2) { GridCreate.GridDisplay(P1_board); }// if player input is 2 do what code says

                            else if (choice == 3) // if player input is 3 then play the players turn
                            {
                                int[] Coordinates = Coord_Input.Coord_Inputing();
                                if (P2_board[Coordinates[0], Coordinates[1]] == 1)
                                {
                                    Console.WriteLine("That is a hit on the enemy!\n ");
                                    P1_HitBoard[Coordinates[0], Coordinates[1]] = 2;//record hit
                                    P2_board[Coordinates[0], Coordinates[1]] = 2;// record hit x2
                                    p_turn = false; // end the current turn automatically after the shot results 
                                }
                                else if (P2_board[Coordinates[0], Coordinates[1]] == 0)
                                {
                                    Console.WriteLine("That is a miss! \n");
                                    P1_HitBoard[Coordinates[0], Coordinates[1]] = 1; //record miss
                                    p_turn = false; // end the current turn automatically after the shot results 
                                }
                                else if (P2_board[Coordinates[0], Coordinates[1]] == 2)// if all validations somehow fail theres this one
                                {
                                    Console.WriteLine("This grid square is already sunk!");
                                }
                            }
                        }
                        else if (i == 1) // player 2s turn
                        {
                            if (choice == 1) { GridCreate.GridDisplay(P2_HitBoard); }// same as p1s turn code is identical

                            else if (choice == 2) { GridCreate.GridDisplay(P2_board); }// same as p1s turn code is identical

                            else if (choice == 3)// everything here is identical to P1 I jsut copy pasted it ok
                            {
                                int[] Coordinates = Coord_Input.Coord_Inputing();
                                if (P1_board[Coordinates[0], Coordinates[1]] == 1)
                                {
                                    P2_HitBoard[Coordinates[0], Coordinates[1]] = 2;
                                    P1_board[Coordinates[0], Coordinates[1]] = 2;
                                    Console.WriteLine("That is a hit on the enemy! \n");
                                    p_turn = false;
                                }
                                else if (P1_board[Coordinates[0], Coordinates[1]] == 0)
                                {
                                    Console.WriteLine("That is a miss!\n ");
                                    P2_HitBoard[Coordinates[0], Coordinates[1]] = 1;
                                    p_turn= false;
                                }
                                else if (P1_board[Coordinates[0], Coordinates[1]] == 2)
                                {
                                    Console.WriteLine("This grid square is already sunk!");
                                }
                            }
                        }
                    }
                }

            }
            if (Checks.Win_Check(P1_board))// checks if P1 won and displays it
            {
                Console.WriteLine("Player 1 wins!");
                return false;
            }
            else if (Checks.Win_Check(P2_board))//checks if P2 won and displays it
            {
                Console.WriteLine("Player 2 wins!");
                return true;
            }
            else // if again somehow all 3 verifications are broken and this is used I dont even care im doing this to shut up the error code
            {
                return false;
            }
            
        }
    }
}
