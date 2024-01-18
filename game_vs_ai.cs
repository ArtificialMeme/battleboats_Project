using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace battleboats
{
    internal class game_vs_ai
    {
        public static bool Game_vs_bot()
        {
            Console.WriteLine("Hello captain! Our first order of buisness is for you to pick your");
            Console.WriteLine("boat's starting positions!");

            int[,] P1_board = BoatPlace.BoatPlacing(GridCreate.GridCreation()); //Player gets to palce their ships
            int[,] P1_HitBoard = GridCreate.GridCreation(); // Player blank Hit Check board is created


            int[,] P2_board = ai_boatplace.BoatPlacing(GridCreate.GridCreation()); // AI boatplace function called 
            int[,] P2_HitBoard = GridCreate.GridCreation();// AI blank Hit Check box is created

            bool temp = false; // a temporary variable used to check for a winner and break a loop

            Console.WriteLine("Now that you have your board ready, we can begin!");


            while ((Checks.Invert(Checks.Win_Check(P1_board)) && Checks.Invert(Checks.Win_Check(P2_board))) || temp)
            { // above code checks for a winner

                for (int i = 0; i <= 1; i++) // Cycles between the AI turn and player turn
                { 
                    if (Checks.Win_Check(P1_board) || (Checks.Win_Check(P2_board)))
                    {
                        break; // if either player or bot has won it breaks the loop
                    }
                    bool p_turn = true;
                    while (p_turn)
                    {
                  
                        if (Checks.Win_Check(P1_board) || (Checks.Win_Check(P2_board) || temp))
                        {
                            break; // if either player or bot has won it breaks out of the if statement
                        }

                        if (i == 0)
                        {
                            // player options listed neatly
                            Console.WriteLine("Your options are:");
                            Console.WriteLine("1. Display your own hit checking grid.");
                            Console.WriteLine("2. Display your own ship grid.");
                            Console.WriteLine("3. Attempt to shoot at the enemy! (this ends your turn)\n\n");

                            int choice = Convert.ToInt32(Console.ReadLine());//Need to make an input verification thingy here

                            if (choice == 1) { GridCreate.GridDisplay(P1_HitBoard); } // Displays Hit cheking grid

                            else if (choice == 2) { GridCreate.GridDisplay(P1_board); }// displays own ship grid

                            else if (choice == 3) //plays the player turn by allowing them to take a shot at coordinates
                            {
                                int[] Coordinates = Coord_Input.Coord_Inputing();
                                if (P2_board[Coordinates[0], Coordinates[1]] == 1) // if coords match a ship, its a hit
                                {
                                    Console.WriteLine("That is a hit on the enemy!\n ");
                                    P1_HitBoard[Coordinates[0], Coordinates[1]] = 2;
                                    P2_board[Coordinates[0], Coordinates[1]] = 2;
                                    p_turn = false;
                                }
                                else if (P2_board[Coordinates[0], Coordinates[1]] == 0)//if coords do not match ship, its a miss
                                {
                                    Console.WriteLine("That is a miss! \n");
                                    P1_HitBoard[Coordinates[0], Coordinates[1]] = 1;
                                    p_turn = false;
                                }
                                else if (P2_board[Coordinates[0], Coordinates[1]] == 2)// if coords not already verified it just prompts the player to repeat their turn
                                {
                                    Console.WriteLine("\nThis grid square is already sunk!");
                                    Console.WriteLine("Please try again!\n");
                                }
                                // should probably add an else statement here in case the 2 lines of verification are broken
                                // but it also seems unneccessary soo....
                            }
                        }
                        else if (i == 1) // the bots turn starts
                        {
                            bool temp2 = true;
                            while (temp2)
                            {
                                Random rnd = new Random();
                                int[] bot_choice = { rnd.Next(8), rnd.Next(8) }; // generates random cordinates to strike
                                if (P2_HitBoard[bot_choice[0], bot_choice[1]] == 0)
                                {
                                    temp2 = false;
                                    Console.WriteLine($"The AI has struck coordinates {bot_choice[0]}, {bot_choice[1]}!"); // tells player where bot has struck
                                    if (P1_board[bot_choice[0], bot_choice[1]] == 1)// Checks if coordinates lign up with ship
                                    {
                                        Console.WriteLine("That is a hit on one of your ships!\n\n");// If they do say hit
                                        P1_board[bot_choice[0], bot_choice[1]] = 2;// then sink ship
                                        P2_HitBoard[bot_choice[0], bot_choice[1]] = 2;// and record hit
                                        p_turn = false;// end turn
                                    }
                                    else// otherwise..
                                    {
                                        Console.WriteLine("That is a miss!\n\n");// say miss
                                        P2_HitBoard[bot_choice[0], bot_choice[1]] = 1;// record miss
                                        p_turn = false;// end turn
                                    }
                                }
                                else // if the bot shoots coords that have already been shot it resets the bots turn
                                {
                                    Console.WriteLine("Those coordinates have already been hit.");
                                    i = i - 1;
                                }


                            }
                        }
                    }
                }
            }
            if (Checks.Win_Check(P1_board))// performs win check again just in case if player won display it
            {
                Console.WriteLine("Player 1 wins!");
                return false;
            }
            else if (Checks.Win_Check(P2_board))// performs win check on bot, if it won display it
            {
                Console.WriteLine("The AI has defeated you!");
                return true;
            }
            return false; // at this point I have so much verification that I will not add anything here except just a 
                          // wrong return statement so the program doesn't scream at me that "nOt aLl pAtHs rEtUrN A vAlUe"
        }
    }
}
