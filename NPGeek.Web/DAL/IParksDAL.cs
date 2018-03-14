using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NPGeek.Web.Models;
using System.Data.SqlClient;

namespace NPGeek.Web.DAL
{
	public class IParksDAL
	{
		private string connectionString;

		public IParksDAL(string dbConnectionString)
		{
			connectionString = dbConnectionString;
		}


		

	}
}