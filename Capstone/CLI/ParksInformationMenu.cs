using Capstone.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Capstone.DAL;

namespace Capstone.CLI
{
    public class ParksInformationMenu : Menu
    {
        public ParksInformationMenu(ParkModel park)
        {
            this.Park = park;
        }

        public ParkModel Park { get; set; }

        public CampgroundSqlDAO CampgroundDAO { get; }

        public void Display()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Park Information");
                Console.WriteLine("----------------");
                Console.WriteLine($"{this.Park.Name}");
                Console.WriteLine($"{"Location:".PadRight(19)}{this.Park.Location}");
                Console.WriteLine($"{"Established:".PadRight(19)}{this.Park.Establish_Date}");
                Console.WriteLine($"{"Area:".PadRight(19)}{this.Park.Area}");
                Console.WriteLine($"{"Annual Visitors:".PadRight(19)}{this.Park.Visitors}");
                Console.WriteLine();
                Console.WriteLine($"{this.Park.Description}");
                Console.WriteLine();
                Console.WriteLine("1) View Campgrounds");
 //               Console.WriteLine("2) Search for Reservation");
                Console.WriteLine("Q) Return to Previous Screen");
                Console.WriteLine();
                Console.Write("> Pick One: ");

                string choice = Console.ReadLine();

                if (choice.ToLower() == "q")
                {
                    break;
                }

                try
                {
                    int numChoice = int.Parse(choice);

                    if (numChoice == 1)
                    {
                        ParkCampgroundsMenu pcm = new ParkCampgroundsMenu(this.Park);
                        pcm.Display();
                        continue;
                    }
                    else if (numChoice == 2)
                    {
                        continue;
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Try Again.");
                        Console.WriteLine("Press any key to continue.");
                        Console.ReadKey();
                        continue;
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Invalid input. Try Again.");
                    Console.WriteLine("Press any key to continue.");
                    Console.ReadKey();
                    continue;
                }
                
            }
        }
    }
}
