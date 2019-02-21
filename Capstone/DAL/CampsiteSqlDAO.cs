using System;
using System.Collections.Generic;
using System.Text;
using Capstone.Models;
using System.Data.SqlClient;

namespace Capstone.DAL
{
    public class CampsiteSqlDAO : ICampsiteDAO
    {
        private string ConnectionString;

        public CampsiteSqlDAO(string connectionString)
        {
            this.ConnectionString = connectionString;
        }

        public IList<CampsiteModel> GetCampsites(int campground_id)
        {
            List<CampsiteModel> campsites = new List<CampsiteModel>();

            try
            {
                using (SqlConnection conn = new SqlConnection(this.ConnectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("select * from site where campground_id = @campground_id ");
                    cmd.Parameters.AddWithValue("@campground_id", campground_id);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        CampsiteModel campsite = ConvertReaderToCampsite(reader);
                        campsites.Add(campsite);
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("There was an error getting campsites.");
                Console.WriteLine(ex.Message);
                throw;
            }

            return campsites;
        }

        private CampsiteModel ConvertReaderToCampsite(SqlDataReader reader)
        {
            CampsiteModel campsite = new CampsiteModel();
            campsite.Site_Id = Convert.ToInt32(reader["site_id"]);
            campsite.Campground_Id = Convert.ToInt32(reader["campground_id"]);
            campsite.Site_Number = Convert.ToInt32(reader["site_number"]);
            campsite.Max_Occupancy = Convert.ToInt32(reader["max_occupancy"]);
            campsite.Accessible = Convert.ToBoolean(reader["accessible"]);
            campsite.Max_RV_Length = Convert.ToInt32(reader["max_rv_length"]);
            campsite.Utilities = Convert.ToBoolean(reader["utilities"]);
            return campsite;
        }
    }
}
