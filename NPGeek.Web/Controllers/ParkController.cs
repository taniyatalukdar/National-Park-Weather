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
        public ParkController(IParksDAL dal)
        {
            this.dal = dal;
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
    }
}