using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NPGeek.Web.Models;
using NPGeek.Web.DAL;

namespace NPGeek.Web.DAL
{
	public interface IWeatherDAL
	{
		List<Weather> GetForecast(string parkCode);
	}
}