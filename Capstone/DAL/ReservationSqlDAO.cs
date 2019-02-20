﻿using System;
using System.Collections.Generic;
using System.Text;
using Capstone.Models;
using System.Data.SqlClient;

namespace Capstone.DAL
{
    public class ReservationSqlDAO : IReservationDAO
    {
        public ReservationSqlDAO(string connectionString)
        {
            this.ConnectionString = connectionString;
        }

        private string ConnectionString;

        public bool PlaceReservation(string name, int site_Id, DateTime from_Date, DateTime to_Date)
        {
            bool isSuccessful = false;

            try
            {
                using (SqlConnection conn = new SqlConnection(this.ConnectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("insert into reservation values (@site_Id, @name, @from_date, @to_date)", conn);
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@from_date", from_Date);
                    cmd.Parameters.AddWithValue("@to_date", to_Date);
                    cmd.Parameters.AddWithValue("@site_Id", site_Id);

                    if (cmd.ExecuteNonQuery() == 1)
                    {
                        isSuccessful = true;
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Error occurred placing reservation");
                Console.WriteLine(ex.Message);
                throw;
            }

            return isSuccessful;
        }
    }
}