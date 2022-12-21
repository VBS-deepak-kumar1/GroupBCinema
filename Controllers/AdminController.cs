using System;
using GroupBCinema.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace GroupBCinema.Controllers
{
    public class AdminController : Controller
    {
        public AdventureWorks2017Entities1 db = new AdventureWorks2017Entities1();
        //[HttpGet]
        public ActionResult AdminLogIn()
        {
            return View();
        }
        // GET: Admin
        [HttpPost]
        public ActionResult AdminLogIn(GroupBCinema.Models.Admin ad )
        {
            using (AdventureWorks2017Entities1 objectDataModel1 = new AdventureWorks2017Entities1())
            {
                var adm = objectDataModel1.Admins.Where(x => x.AdminUserName == ad.UserName && x.AdminPassword == ad.UserPassword).SingleOrDefault();
                if (adm == null)
                {
                    ModelState.AddModelError("", "Invalid Username or Password");
                    return View("AdminLogIn", ad);
                }
                else
                {
                    Session["AdminUserId"] = adm.AdminUserId.ToString();
                    Session["AdminUserName"] = ad.UserName;
                    Session["AdminPassword"] = ad.UserPassword;
                    return RedirectToAction("Dashboard");
                }
            }


        }
        public ActionResult Dashboard()
        {
            if (Session["AdminUserId"] == null)
            {
                return RedirectToAction("AdminLogIn");
            }
            else
            {

                return View();
            }
            
        }
        public ActionResult Logout()
        {
            Session["AdminUserId"] = null;
            Session["AdminUserName"] = null;
            Session["AdminPassword"] = null;
            return RedirectToAction("AdminLogIn", "Admin");
        }

    }
}
       