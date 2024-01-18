using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using System.Runtime.Intrinsics.X86;


namespace battleboats
{
    internal class Coord_Input
    {
        public static int[] Coord_Inputing() //function to validate coordinate input from player
        {
            Console.WriteLine("Enter Coordinates from A1 to H8: ");
            string inp = Console.ReadLine();
            char[] ss = inp.ToCharArray(); //spltis up milti- char input into a list

            

            if (ss.Count() != 2) //checks list isnt longer than 2 (coordinates are only 2 char long)
            {
                Console.WriteLine("\n Sorry that is not a valid input! \n");
                return Coord_Inputing();
            }

            char s = char.ToUpper(ss[0]);

            char sss = ss[1];

            Console.WriteLine($"{s} {sss}"); 


            if ((s == 'A' || s == 'B' || s == 'C' || s == 'D' || s == 'E' || s == 'F' || s == 'G' || s == 'H') && (sss == '1' || sss == '2' || sss == '3' || sss == '4' || sss == '5' || sss == '6' || sss == '7' || sss == '8'))
            { //Checks if the coordinates are between A-H or 1-8 (theres probably a smarter way to do thi but I spent 
              //half an hour trying to figure it out to no avail so I just wrote the alphabet...  
            }
            else
            {
                Console.WriteLine("\n Sorry that is not a valid input! \n");// if doesnt pass valdiation off to repeat this all you go
                return Coord_Inputing();
            }

            //if all validations are passed the values now need to be converted into what I need 

            int[] Coordinates = { 0, 0 };// create the useful numerical coordinates

            switch (s)// again there is probably a smarter way to do this but I am not wasting any more time this is good enough
            {
                case 'A':
                    Coordinates[0] = 0;
                    break;
                case 'B':
                    Coordinates[0] = 1;
                    break;
                case 'C':
                    Coordinates[0] = 2;
                    break;
                case 'D':
                    Coordinates[0] = 3;
                    break;
                case 'E':
                    Coordinates[0] = 4;
                    break;
                case 'F':
                    Coordinates[0] = 5;
                    break;
                case 'G':
                    Coordinates[0] = 6;
                    break;
                case 'H':
                    Coordinates[0] = 7;
                    break;
                default:
                    Console.WriteLine("AAAAAAA"); // if this ever prints I am deleting this project
                    break;
            }
            Coordinates[1] = Convert.ToInt32(sss)-49;// messes around with ascii value to do what I want
                                                     // definately didnt use trial and error to do this because I was too
                                                     // lazy to look up an ascii table...
            return Coordinates;
        }
    }
}
