using GroupBCinema.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;


namespace GroupBCinema.Controllers
{
    public class moviesController : Controller
    {
        private DataModel db = new DataModel();

        // GET: movies
        public ActionResult Index()
        {
            if (Session["AdminUserId"] == null)
            {
                return RedirectToAction("AdminLogIn", "Admin");
               // return View(db.movies.ToList());
            }
            else
            {
                return View(db.movies.ToList());
                //return RedirectToAction("AdminLogIn", "Admin");
            }
        }
        public ActionResult MovieList()
        {
            return View();
        }

        // GET: movies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            movy movy = db.movies.Find(id);
            if (movy == null)
            {
                return HttpNotFound();
            }
            return View(movy);
        }

        // GET: movies/Create
        public ActionResult Create()
        {


            if (Session["AdminUserId"] == null)
            {
                return RedirectToAction("AdminLogIn","Admin");
            }
            else
            {

                return View();
            }

        }

        // POST: movies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "movie_id,movie_name,genre,runtime,release_date,language,subtitle,description,image_path,video_path,rating,director")] movy movy)
        {
            if (Session["AdminUserId"] == null)
            {
                return RedirectToAction("AdminLogIn", "Admin");
                // return View(db.movies.ToList());
            }
            else
            {
                if (ModelState.IsValid)
                {
                    db.movies.Add(movy);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                return View(movy);
            }
          
        }

        // GET: movies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            movy movy = db.movies.Find(id);
            if (movy == null)
            {
                return HttpNotFound();
            }
            return View(movy);
        }

        // POST: movies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "movie_id,movie_name,genre,runtime,release_date,language,subtitle,description,image_path,video_path,rating,director")] movy movy)
        {
            if (ModelState.IsValid)
            {
                db.Entry(movy).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(movy);
        }

        // GET: movies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            movy movy = db.movies.Find(id);
            if (movy == null)
            {
                return HttpNotFound();
            }
            return View(movy);
        }

        // POST: movies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            movy movy = db.movies.Find(id);
            db.movies.Remove(movy);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
