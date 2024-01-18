using System.Xml.Serialization;

namespace battleboats
{
    internal class Program
    {
        static void Main()
        {
            // Basic game intro gibberish
            Console.WriteLine("\n\nWelcome to BATTLE BOATS!");

            Console.WriteLine("In this game you get to engage your friends in a strategic naval battle!\n");

            Console.WriteLine("Here are your options:");

            // Menu options displayed
            Console.WriteLine("1. Start a new game! (VS player) ");
            Console.WriteLine("2. Start a new game! (VS AI) ");
            Console.WriteLine("3. Display Rules.");
            Console.WriteLine("4. Exit the program.");

            string choice = Console.ReadLine();
            int choice1 = 0;

            if (Checks.Int_Check(choice.ToCharArray())) //Validates input using function
            {
                choice1 = Convert.ToInt32(choice);
            }
            else // if input is invalid just resents the entire game by sending the player back to the start of main method
            {
                Console.WriteLine("\n\n Invalid input, please try again! \n\n");
                Main();
            }

            if (choice1 == 1) // starts new game
            {
                Game.New_game();
            }
            else if (choice1 == 3) // displays rules
            {
                Console.WriteLine("This is a simple game of BattleShips.\n ");
                Console.WriteLine("Each player gets a 8x8 grid in which they can place a series of ships.\n ");
                Console.WriteLine("The goal is to guess where the enemy ships are and sink them!\n");
                Console.WriteLine("You get a submarines (2 tiles), 1 destroyer (2 tiles), 1 cruiser (3 tiles),");
                Console.WriteLine("1 battleship (4 tiles) and 1 carrier (5 tiles).\n");
                Console.WriteLine("Each turn you will be given the chance to review your own ship grid, ");
                Console.WriteLine("review a separate grid of your own attempts at hitting the enemy or end your ");
                Console.WriteLine("turn by taking a shot at the enemy board. \n");
                Console.WriteLine("A number on your ship grid means there are no ships there. A number 1 indicates");
                Console.WriteLine("you have a living ship there, and a number 2 indicates that the enemy has sunk");
                Console.WriteLine("the ship that used to reside on that tile.\n");
                Console.WriteLine("As for your own hitting grid, a 0 represents no shooting attempts made, a 1");
                Console.WriteLine("represents a miss and a 2 represents a hit on an enemy.\n");
                Console.WriteLine("The winner of the game is the person who first sinks the entirety of the enemy");
                Console.WriteLine("fleet. To sink a ship you need to hit all grid tiles it covers.");
                Console.WriteLine("Happy playing! \n\n\n");
                Main();
            }
            else if (choice1 == 4) // exits program
            {
                Console.WriteLine("Thank you for playing, goodbye!");
                System.Environment.Exit(0);
            }
            else if (choice1 == 2) //starts new game against bot
            {
                game_vs_ai.Game_vs_bot();
            }
            else // if somehow despite verification input is invalid, it sends player back to main method
            {
                Console.WriteLine("Invalid input, try again!\n\n\n");
                Main();
            }

        }
    }
}
