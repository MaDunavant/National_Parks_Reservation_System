using System;
using System.Collections.Generic;
using System.Text;
using Capstone.DAL;
using Capstone.Models;


namespace Capstone.CLI
{
    public class ParkCampgroundsMenu
    {
        public ParkModel Park { get; }
        public CampgroundSqlDAO CampgroundSqlDAO { get; }
        public CampsiteSqlDAO CampsiteSqlDAO { get; }

        public ParkCampgroundsMenu(ParkModel park, CampgroundSqlDAO campgroundSqlDAO)
        {
            this.Park = park;
            this.CampgroundSqlDAO = campgroundSqlDAO;
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

                IList<CampgroundModel> cmpg = new List<CampgroundModel>();
                cmpg = this.CampgroundSqlDAO.GetCampgrounds(Park.Park_Id);
                for (int i = 0; i < cmpg.Count; i++)
                {
                    Console.WriteLine($"({i+1}) {"cmpg[i].Name".PadRight(20)} {"cmpg[i].Open_From_MM".PadRight(10)}{"cmpg[i].Open_To_MM".PadRight(10)}{cmpg[i].Daily_Fee}");
                }

                try
                {
                    Console.WriteLine();
                    Console.WriteLine("(1) Select campground");
                    Console.WriteLine("(2) Return to Park Information Menu");
                    Console.Write("Please make a selection: ");
                    string choice = Console.ReadLine();
                    int numChoice = int.Parse(choice);
                    if (numChoice == 2)
                    {
                        break;
                    }
                    else if (numChoice == 1)
                    {
//                        ReservationMenu rm = new ReservationMenu(cmpg);
//                        rm.Display();
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
                catch(Exception ex)
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
