using System;
using System.Collections.Generic;
using System.Text;
using Capstone.DAL;
using Capstone.Models;


namespace Capstone.CLI
{
    public class ParkCampgroundsMenu : Menu
    {
        public ParkModel Park { get; }

        public ParkCampgroundsMenu(ParkModel park)
        {
            this.Park = park;
        }

        public void Display()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine($"{ Park.Name}");
                Console.WriteLine("Campground Selection:");
                Console.WriteLine("---------------------");
                Console.WriteLine();
                Console.WriteLine("#   Name".PadRight(40) + "Open".PadRight(10) + "Close".PadRight(10) + "Daily Rate");
                Console.WriteLine("".PadRight(70,'-'));

                IList<CampgroundModel> cmpg = new List<CampgroundModel>();
                cmpg = this.CampgroundSqlDAO.GetCampgrounds(Park.Park_Id);
                for (int i = 0; i < cmpg.Count; i++)
                {
                    Console.WriteLine($"({i + 1}) {cmpg[i].Name.PadRight(35)} {MonthNames[cmpg[i].Open_From_MM].PadRight(10)}{MonthNames[cmpg[i].Open_To_MM].PadRight(10)}{cmpg[i].Daily_Fee:C2}");
                }

                try
                {
                    Console.WriteLine();
                    Console.WriteLine("(1) Select campground");
                    Console.WriteLine("(Q) Return to Previous Screen");
                    Console.WriteLine();
                    Console.Write("Please make a selection: ");
                    string choice = Console.ReadLine();
                    int numChoice = int.Parse(choice);
                    if (numChoice == 2)
                    {
                        break;
                    }
                    else if (numChoice == 1)
                    {
                        ReservationMenu rm = new ReservationMenu(Park);
                        rm.Display();
                        continue;
                    }
                    else
                    {
                        Console.WriteLine("Invalid entry!  Try Again.");
                        Console.WriteLine("Press any key to continue.");
                        Console.ReadKey();
                        continue;
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine("Invalid entry!  Try Again.");
                    Console.WriteLine("Press any key to continue.");
                    Console.ReadKey();
                    continue;
                }
            }

        }
    }


}
