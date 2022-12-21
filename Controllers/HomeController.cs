using GroupBCinema.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GroupBCinema.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            DataModel Db = new DataModel();

            var tuple = new Tuple<IEnumerable<movy>, IEnumerable<theater>>(Db.movies.ToList(), Db.theaters.ToList());
            return View(tuple);
            
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}