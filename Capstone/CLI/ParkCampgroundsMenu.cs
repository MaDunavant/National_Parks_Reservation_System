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
        public Dictionary<int, string> MonthNames { get; } = new Dictionary<int, string>
        {
            {1,"January" },
            {2,"February" },
            {3,"March" },
            {4,"April" },
            {5,"May" },
            {6,"June" },
            {7,"July" },
            {8,"August" },
            {9,"September" },
            {10,"October" },
            {11,"November" },
            {12,"December" }
        };

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
