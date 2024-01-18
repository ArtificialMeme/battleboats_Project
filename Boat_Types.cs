using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace battleboats
{
    internal class Boat_Types
    {
        public static int Boat_Selection(int boat)
        {
            int boat_no;

            switch (boat) // Converts the ascending boat number into the boat length
            {
                case 0:
                    boat_no = 2;
                    break;
                case 1:
                    boat_no = 2;
                    break;
                case 2:
                    boat_no = 3;
                    break;
                case 3:
                    boat_no = 4;
                    break;
                case 4:
                    boat_no = 5;
                    break;
                default:
                    boat_no = 0;
                    break;

            }
            return boat_no;
        }
        public static string Boat_Name(int boat)
        {
            string boat_name = "";

            switch (boat) // COnverts the boat number into the boat name 
            {
                case 0:
                    boat_name = "Submarine";
                    break;

                case 1:
                    boat_name = "Destroyer";
                    break;

                case 2:
                    boat_name = "Cruiser";
                    break;

                case 3:
                    boat_name = "Battleship";
                    break;

                case 4:
                    boat_name = "Carrier";
                    break;


            }

            return boat_name;
        }
    }
}
