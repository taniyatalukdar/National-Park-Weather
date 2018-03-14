using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NPGeek.Web.Models;
using System.Data.SqlClient;

namespace NPGeek.Web.DAL
{
    public class ParkSqlDAL : IParksDAL
    {
        const string connectionString = @"Server =.\SQLEXPRESS; database = npgeek; Trusted_Connection = True;";

        public List<Park> GetParks()
        {
            List<Park> parks = new List<Park>();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(@"SELECT * FROM park;", conn);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while(reader.Read())
                    {
                        Park park = MapRowToPark(reader);
                            parks.Add(park);
                    }

                    return parks;
                }
            }
            catch (SqlException)
            {
                throw;
            }    
        }

        public Park GetOnePark(string code)
        {
            Park park = new Park();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(@"SELECT * FROM park WHERE parkCode = @code;", conn);
                    cmd.Parameters.AddWithValue("@code", code);

                    SqlDataReader reader = cmd.ExecuteReader();
                    if(reader.Read())
                    {
                        park = MapRowToPark(reader);
                    }
                    return park;
                }
            }
            catch(SqlException)
            {
                throw;
            }
        }
        private static Park MapRowToPark(SqlDataReader reader)
        {
            return new Park
            {
                ParkCode = Convert.ToString(reader["parkCode"]),
                ParkName = Convert.ToString(reader["parkName"]),
                State = Convert.ToString(reader["state"]),
                Acreage = Convert.ToInt32(reader["acreage"]),
                Elevation = Convert.ToInt32(reader["elevationInFeet"]),
                MilesOfTrail = Convert.ToDouble(reader["milesOfTrail"]),
                NumberOfCampsites = Convert.ToInt32(reader["numberOfCampsites"]),
                Climate = Convert.ToString(reader["climate"]),
                YearFounded = Convert.ToInt32(reader["yearFounded"]),
                AnnualVisitorCount = Convert.ToInt32(reader["annualVisitorCount"]),
                InspirationalQuote = Convert.ToString(reader["inspirationalQuote"]),
                InspirationalQuoteSource = Convert.ToString(reader["inspirationalQuoteSource"]),
                ParkDescription = Convert.ToString(reader["parkDescription"]),
                EntryFee = Convert.ToInt32(reader["entryFee"]),
                NumberOfAnimalSpecies = Convert.ToInt32(reader["numberOfAnimalSpecies"])
            };
        }
    }
}