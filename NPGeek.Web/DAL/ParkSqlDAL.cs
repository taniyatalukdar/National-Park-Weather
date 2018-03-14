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

		public List<Park> GetParks(string code)
		{
			List<Park> parks = new List<Park>();
			try
			{
				using (SqlConnection conn = new SqlConnection(connectionString))
				{
					conn.Open();
					SqlCommand cmd = new SqlCommand(@"SELECT * FROM parks;", conn);
					SqlDataReader reader = cmd.ExecuteReader();

				}
			}
			

			private static Park MapRowToPark(SqlDataReader reader)
			{
				return new Park
				{
