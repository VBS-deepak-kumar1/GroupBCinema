using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.Entity;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GroupBCinema.Models;

namespace GroupBCinema.Controllers
{
    public class ShowsController : Controller
    {
        public DataModel db = new DataModel();
        // GET: Shows
        public ActionResult Index(string theater, string movie)
        {
            if(theater == null || movie == null)
            {
                return RedirectToAction("Index", "Home");
            }

            var movie_details = db.movies.Find(Convert.ToInt32(movie));
            var theater_details = db.theaters.Find(Convert.ToInt32(theater));
            ViewBag.movieObject = movie_details;
            ViewBag.theaterObject = theater_details;
            var ans = db.shows.Where(s => s.movie_id == movie_details.movie_id && s.theater_id == theater_details.theater_id).ToList<show>();
            var tuple = new Tuple<IEnumerable<movy>, IEnumerable<theater>, IEnumerable<show>>(db.movies.ToList(), db.theaters.ToList(), ans);
            return View(tuple);
        }

        // GET: shows/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            show show = db.shows.Find(id);
            if (show == null)
            {
                return HttpNotFound();
            }
            return View(show);
        }

        // GET: shows/Create
        public ActionResult Create()
        {
            if (Session["AdminUserId"] == null)
            {
                return RedirectToAction("AdminLogIn", "Admin");
            }
            else
            {
                ViewBag.movie_id = new SelectList(db.movies, "movie_id", "movie_name");
                ViewBag.theater_id = new SelectList(db.theaters, "theater_id", "theater_name");
                return View();

            }
            
        }

        // POST: shows/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "show_id,movie_id,theater_id,date,timing,price")] show show)
        {
            if (ModelState.IsValid)
            {
                db.shows.Add(show);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.movie_id = new SelectList(db.movies, "movie_id", "movie_name", show.movie_id);
            ViewBag.theater_id = new SelectList(db.theaters, "theater_id", "theater_name", show.theater_id);
            return View(show);
        }

        // GET: shows/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            show show = db.shows.Find(id);
            if (show == null)
            {
                return HttpNotFound();
            }
            ViewBag.movie_id = new SelectList(db.movies, "movie_id", "movie_name", show.movie_id);
            ViewBag.theater_id = new SelectList(db.theaters, "theater_id", "theater_name", show.theater_id);
            return View(show);
        }

        // POST: shows/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "show_id,movie_id,theater_id,date,timing,price")] show show)
        {
            if (ModelState.IsValid)
            {
                db.Entry(show).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.movie_id = new SelectList(db.movies, "movie_id", "movie_name", show.movie_id);
            ViewBag.theater_id = new SelectList(db.theaters, "theater_id", "theater_name", show.theater_id);
            return View(show);
        }

        // GET: shows/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            show show = db.shows.Find(id);
            if (show == null)
            {
                return HttpNotFound();
            }
            return View(show);
        }

        // POST: shows/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            show show = db.shows.Find(id);
            db.shows.Remove(show);
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