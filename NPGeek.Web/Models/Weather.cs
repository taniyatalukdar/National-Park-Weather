using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NPGeek.Web.Models
{
	public class Weather
	{
		public string ParkCode { get; set; }
		public int FiveDayForecastValue { get; set; }
		public int Low { get; set; }
		public int High { get; set; }
		public string Forecast { get; set; }


		public double CalculateLowCelsius()
		{
			return Math.Round((Low - 32) * 0.556, 0);
		}

		public double CalculateHighCelsius()
		{
			return Math.Round((High - 32) * 0.556, 0);

		}
	}
}