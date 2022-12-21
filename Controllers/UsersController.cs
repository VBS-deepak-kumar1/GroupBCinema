using GroupBCinema.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Web;
using System.Web.Mvc;

namespace GroupBCinema.Controllers
{
    public class UsersController : Controller
    {
        public DataModel db = new DataModel();

        //Signin 
        // GET: users
        public ActionResult Signin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Signin(GroupBCinema.user userModel)
        {
            using (DataModel objDataModel = new DataModel())

            {
                var userDetails = objDataModel.users.Where(x => x.email == userModel.email && x.password == userModel.password).FirstOrDefault();

                if (userDetails == null)
                {
                    ModelState.AddModelError("", "Invalid Email or Password");

                    return View("Signin", userModel);
                }
                else
                {
                    Session["email"] = userModel.email;
                    Session["UserName"] = userDetails.first_name;
                    Session["UserId"] = userDetails.user_id;
                    return RedirectToAction("Index", "Home");
                }
            }

        }

        //Logout
        public ActionResult Logout()
        {
            Session["email"] = null;
            Session["UserName"] = null;
            Session["UserId"] = null;
            //Session.Remove("email");

            //String email = (String)Session["email"];
            //Session.Abandon();
            return RedirectToAction("Signin", "users");
        }

        // GET: users
        public ActionResult Register(int id = 0)
        {
            user userModel = new user();
            return View(userModel);
        }

        [HttpPost]
        public ActionResult Register(user userModel)
        {
            using (DataModel objDataModel = new DataModel())
            {
                if (objDataModel.users.Any(x => x.email == userModel.email))
                {
                    //ViewBag.DuplicateMessage = "Account already exists.";
                    ModelState.AddModelError("", "Account already exists");
                    return View("Register", userModel);
                }
                objDataModel.users.Add(userModel);
                objDataModel.SaveChanges();
            }
            ModelState.Clear();
            ViewBag.SuccessMessage = "Registration successful";
            return RedirectToAction("RegisterConfirm", "users");
        }

        public ActionResult RegisterConfirm()
        {
            return View();
        }



    }
}