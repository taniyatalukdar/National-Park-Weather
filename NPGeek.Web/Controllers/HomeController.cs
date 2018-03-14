using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NPGeek.Web.DAL;
using NPGeek.Web.Models;

namespace NPGeek.Web.Controllers
{
    public class HomeController : Controller
    {
        IParksDAL dal;
        public HomeController(IParksDAL dal)
        {
            this.dal = dal;
        }
        // GET: Home
        public ActionResult Index()
        {
            var parks = dal.GetParks();
            return View("Index", parks);
        }
    }
}