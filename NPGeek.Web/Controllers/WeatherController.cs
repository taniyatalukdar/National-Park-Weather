using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NPGeek.Web.DAL;
using NPGeek.Web.Models;

namespace NPGeek.Web.Controllers
{
    public class WeatherController : Controller
    {
		IWeatherDAL dal;

		public WeatherController(IWeatherDAL dal)
		{
			this.dal = dal;
		}
		// GET: Weather
		public ActionResult WeatherDetail(string parkCode)
        {
			var weather = dal.GetForecast(parkCode);
            return View("Weather", weather);
        }


    }
}