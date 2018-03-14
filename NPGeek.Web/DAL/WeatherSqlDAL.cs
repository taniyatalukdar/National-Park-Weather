using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NPGeek.Web.Models;
using System.Data.SqlClient;

namespace NPGeek.Web.DAL
{
	public class WeatherSqlDAL : IWeatherDAL
	{
		const string connectionString = @"Server =.\SQLEXPRESS; database = npgeek; Trusted_Connection = True;";

		public Weather GetForecast(string parkCode)
		{
			Weather weather = new Weather();

			try
			{
				using (SqlConnection conn = new SqlConnection(connectionString))
				{
					conn.Open();
					SqlCommand cmd = new SqlCommand(@"SELECT * FROM weather WHERE parkCode = @parkCode;", conn);
					cmd.Parameters.AddWithValue("@parkCode", parkCode);

					SqlDataReader reader = cmd.ExecuteReader();
					while (reader.Read())
					{
						 weather = MapRowToWeather(reader);
					
					}
					return weather;

				}
			}
			catch (SqlException)
			{
				throw;
			}

		}
	

		private static Weather MapRowToWeather(SqlDataReader reader)
		{
			return new Weather
			{

				ParkCode = Convert.ToString(reader["parkCode"]),
				FiveDayForecastValue = Convert.ToInt32(reader["fiveDayForecastValue"]),
				Low = Convert.ToInt32(reader["low"]),
				High = Convert.ToInt32(reader["high"]),
				Forecast = Convert.ToString(reader["forecast"])
			};


		}
	}
}