using System;
using System.Collections.Generic;
using System.Text;
using Capstone.DAL;
using Capstone.Models;

namespace Capstone.CLI
{
    public class ViewParksMenu
    {
       public void Display() {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("View Parks");
                Console.WriteLine("----------");
                IList<ParkModel> parks = new List<ParkModel>();
                parks = this.ParksDAO.GetParks();

                for (int i=0; i < parks.Count; i++)
                {
                    Console.WriteLine($"({i + 1}) {parks[i].Name}");
                }
                Console.WriteLine("(Q)uit");
                try
                {
                    Console.WriteLine();
                    Console.Write("Pick a Park: ");
                    string choice = Console.ReadLine();
                    if (choice.ToLower() == "q")
                    {
                        break;
                    }

                    int numChoice = int.Parse(choice);

                    if (numChoice <= parks.Count && numChoice > 0)
                    {
                        ParksInformationMenu pim = new ParksInformationMenu(parks[numChoice - 1], this.CampgroundDAO);
                        pim.Display();
                        continue;
                    }
                    else
                    {
                        Console.WriteLine("Invalid entry! Try again.");
                        Console.Write("Press any key to continue");
                        Console.ReadKey();
                        continue;
                    }
                }

                catch (Exception ex)
                {
                    Console.WriteLine("Invalid entry! Try again.");
                    Console.Write("Press any key to continue");
                    Console.ReadKey();
                    continue;
                }
            }
        }
        public ViewParksMenu(ParkSqlDAO parksDAO, CampgroundSqlDAO campgroundDAO)
        {
            this.ParksDAO = parksDAO;
            this.CampgroundDAO = campgroundDAO;
        }

        public ParkSqlDAO ParksDAO { get; set; }
        public CampgroundSqlDAO CampgroundDAO { get; set; }
    }
}
