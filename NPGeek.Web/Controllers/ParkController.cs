using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NPGeek.Web.Models;
using NPGeek.Web.DAL;

namespace NPGeek.Web.Controllers
{
    public class ParkController : Controller
    {
        IParksDAL dal;
        IWeatherDAL dal2;
        public ParkController(IParksDAL dal, IWeatherDAL dal2)
        {
            this.dal = dal;
            this.dal2 = dal2;
        }
        
        // GET: Park
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ParkDetail(string code)
        {
            var park = dal.GetOnePark(code);
            return View("ParkDetail", park);
        }
        public ActionResult WeatherDisplay(string code)
        {
            var weathers = dal2.GetForecast(code);
            return PartialView(weathers);
        }
    }
}