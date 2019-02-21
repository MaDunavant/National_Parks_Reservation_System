using System;
using System.Collections.Generic;
using System.Text;
using Capstone.DAL;
using Capstone.Models;

namespace Capstone.CLI
{
    public class ReservationMenu : Menu
    {
        public ParkModel Park { get; }

        public ReservationMenu(ParkModel park)
        {
            this.Park = park;
        }

        public void Display()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Campground Reservations");
                Console.WriteLine("-----------------------");
                Console.WriteLine();
                Console.WriteLine("#   Name".PadRight(40) + "Open".PadRight(10) + "Close".PadRight(10) + "Daily Rate");
                Console.WriteLine("".PadRight(70, '-'));

                IList<CampgroundModel> cmpg = new List<CampgroundModel>();
                cmpg = this.CampgroundSqlDAO.GetCampgrounds(Park.Park_Id);
                for (int i = 0; i < cmpg.Count; i++)
                {
                    Console.WriteLine($"({i + 1}) {cmpg[i].Name.PadRight(35)} {MonthNames[cmpg[i].Open_From_MM].PadRight(10)}{MonthNames[cmpg[i].Open_To_MM].PadRight(10)}{cmpg[i].Daily_Fee:C2}");
                }

                Console.Write("Which campground (enter 0 to cancel)? ");
                string campgroundChoice = Console.ReadLine();

                Console.Write("What is the arrival date? (YYYY-MM-DD): ");
                string fromDateChoice = Console.ReadLine();

                Console.Write("What is the departure date? (YYYY-MM-DD): ");
                string toDateChoice = Console.ReadLine();

                try
                {
                    int campgroundID = int.Parse(campgroundChoice);
                    DateTime fromDate = DateTime.Parse(fromDateChoice);
                    DateTime toDate = DateTime.Parse(toDateChoice);

                    int reservationDays = (int)(toDate - fromDate).TotalDays + 1;

                    decimal reservationCost = (decimal)reservationDays * cmpg[campgroundID - 1].Daily_Fee;

                    Console.WriteLine("Results Matching Your Search Criteria");
                    Console.WriteLine($"Site No.".PadRight(10) + "Max Occup.".PadRight(12) + "Accessible?".PadRight(13) + "Max RV Length".PadRight(15) + "Utility".PadRight(9) + "Cost");

                    IList<CampsiteModel> availableReservations = new List<CampsiteModel>();
                    availableReservations = this.CampsiteSqlDAO.GetAvailableReservations(cmpg[campgroundID - 1], fromDate, toDate);

                    for (int i = 0; i < availableReservations.Count; i++)
                    {
                        CampsiteModel res = availableReservations[i];
                        Console.WriteLine($"{i + 1} {res.Max_Occupancy} {res.Accessible} {res.Max_RV_Length} {res.Utilities} {reservationCost:C2}");
                    }
                    Console.ReadKey();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Invalid input, try again.");
                    Console.WriteLine("Press any key to continue.");
                    Console.WriteLine(ex.Message);
                    Console.ReadKey();
                    continue;
                }
            }
        }



    }
}
