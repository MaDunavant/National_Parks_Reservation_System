using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using Capstone.DAL;
using Capstone.CLI;

namespace Capstone
{
    class Program
    {
        static void Main(string[] args)
        {
            // Get the connection string from the appsettings.json file
            //IConfigurationBuilder builder = new ConfigurationBuilder()
            //    .SetBasePath(Directory.GetCurrentDirectory())
            //    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            //IConfigurationRoot configuration = builder.Build();

            //string connectionString = configuration.GetConnectionString("Project");

            //ParkSqlDAO parkSqlDAO = new ParkSqlDAO(connectionString);
            //CampgroundSqlDAO campgroundSqlDAO = new CampgroundSqlDAO(connectionString);
            //CampsiteSqlDAO campsiteSqlDAO = new CampsiteSqlDAO(connectionString);
            //ReservationSqlDAO reservationSqlDAO = new ReservationSqlDAO(connectionString);

            Menu menu = new Menu();

            ViewParksMenu vpm = new ViewParksMenu();
            vpm.Display();
        }
    }
}
