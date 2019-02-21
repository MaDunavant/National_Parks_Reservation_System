﻿using System;
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

                if (campgroundChoice == "0")
                {
                    break;
                }
                else if(int.Parse(campgroundChoice) > cmpg.Count || int.Parse(campgroundChoice) < 1)
                {
                    Console.WriteLine("Invalid input, try again.");
                    Console.WriteLine("Press any key to continue.");
                    Console.ReadKey();
                    continue;
                }

                Console.Write("What is the arrival date? (YYYY-MM-DD): ");
                string fromDateChoice = Console.ReadLine();

                Console.Write("What is the departure date? (YYYY-MM-DD): ");
                string toDateChoice = Console.ReadLine();

                try
                {
                    int campgroundID = int.Parse(campgroundChoice);
                    DateTime fromDate = DateTime.Parse(fromDateChoice);
                    DateTime toDate = DateTime.Parse(toDateChoice);
                    if (toDate < fromDate)
                    {
                        Console.WriteLine("The end date must be after the beginning date!");
                        Console.Write("Press any key to try again.");
                        Console.ReadKey();
                        continue;
                    }
                    if (!CampgroundSqlDAO.IsOpen(cmpg[campgroundID - 1], fromDate, toDate))
                    {
                        Console.WriteLine("The campground is closed during the time you have selected.");
                        Console.Write("Press any key to re-select.");
                        Console.ReadKey();
                        continue;

                    }

                    int reservationDays = (int)(toDate - fromDate).TotalDays + 1;

                    decimal reservationCost = (decimal)reservationDays * cmpg[campgroundID - 1].Daily_Fee;

                    Console.WriteLine("Results Matching Your Search Criteria");
                    Console.WriteLine($"Site No.".PadRight(10) + "Max Occup.".PadRight(12) + "Accessible?".PadRight(13) + "Max RV Length".PadRight(15) + "Utility".PadRight(9) + "Cost");

                    IList<CampsiteModel> availableReservations = new List<CampsiteModel>();
                    availableReservations = this.CampsiteSqlDAO.GetAvailableReservations(cmpg[campgroundID - 1], fromDate, toDate);

                    if (availableReservations.Count == 0)
                    {
                        Console.WriteLine("There are no reservations matching your criteria.");
                        Console.Write("Please press any key to make new selections.");
                        Console.ReadKey();
                        continue;
                    }

                    for (int i = 0; i < availableReservations.Count; i++)
                    {
                        CampsiteModel res = availableReservations[i];
                        Console.WriteLine($"{res.Site_Id}".PadRight(10) + $"{res.Max_Occupancy}".PadRight(12) + $"{((res.Accessible)?"Yes":"No")}".PadRight(13) + $"{res.Max_RV_Length}".PadRight(15) + $"{((res.Utilities)?"Yes":"No")}".PadRight(9) + $"{reservationCost:C2}");
                    }
                    Console.WriteLine();
                    Console.Write("Please select a campsite: ");
                    Console.Write("'0' to return to the menu.");
                    int whichCampsite = int.Parse(Console.ReadLine());
                    bool validCampsite = false;
                    foreach (CampsiteModel csite in availableReservations)
                    {
                        if (whichCampsite == csite.Site_Id)
                        {
                            validCampsite = true;
                        }
                    }
                    if (!validCampsite)
                    {
                        throw new Exception("Invalid campsite.");
                    }
                    if (whichCampsite == 0)
                    {
                        continue;
                    }
                    Console.Write("Please enter the name for the reservation: ");
                    string camperName = Console.ReadLine();
                    if (camperName == "")
                    {
                        throw new Exception("A name must be entered.");
                    }
                    int reservationId = this.ReservationSqlDAO.PlaceReservation(camperName, whichCampsite, fromDate, toDate);
                    Console.WriteLine("Your reservation has been successfuly placed.");
                    Console.WriteLine($"The reservation ID is: {reservationId}");
                    Console.Write("Thank you for using the National Parks Reservation System!");
                    Console.ReadKey();
                    break;
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
