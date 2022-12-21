using GroupBCinema.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace GroupBCinema.Controllers
{
        public class theatersController : Controller
        {
            private DataModel db = new DataModel();

            // GET: theaters
            public ActionResult Index()
            {
            if (Session["AdminUserId"] == null)
            {
                return RedirectToAction("AdminLogIn", "Admin");
            }
            else
            {
                return View(db.theaters.ToList());

            }

          
            }

            // GET: theaters/Details/5
            public ActionResult Details(int? id)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                theater theater = db.theaters.Find(id);
                if (theater == null)
                {
                    return HttpNotFound();
                }
                return View(theater);
            }

            // GET: theaters/Create
            public ActionResult Create()
            {
            if (Session["AdminUserId"] == null)
            {
                return RedirectToAction("AdminLogIn", "Admin");
            }
            else
            {
                return View();

            }
         
            }

            // POST: theaters/Create
            // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
            // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
            [HttpPost]
            [ValidateAntiForgeryToken]
            public ActionResult Create([Bind(Include = "theater_id,theater_name,city,country")] theater theater)
            {
                if (ModelState.IsValid)
                {
                    db.theaters.Add(theater);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                return View(theater);
            }

            // GET: theaters/Edit/5
            public ActionResult Edit(int? id)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                theater theater = db.theaters.Find(id);
                if (theater == null)
                {
                    return HttpNotFound();
                }
                return View(theater);
            }

            // POST: theaters/Edit/5
            // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
            // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
            [HttpPost]
            [ValidateAntiForgeryToken]
            public ActionResult Edit([Bind(Include = "theater_id,theater_name,city,country")] theater theater)
            {
                if (ModelState.IsValid)
                {
                    db.Entry(theater).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(theater);
            }

            // GET: theaters/Delete/5
            public ActionResult Delete(int? id)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                theater theater = db.theaters.Find(id);
                if (theater == null)
                {
                    return HttpNotFound();
                }
                return View(theater);
            }

            // POST: theaters/Delete/5
            [HttpPost, ActionName("Delete")]
            [ValidateAntiForgeryToken]
            public ActionResult DeleteConfirmed(int id)
            {
                theater theater = db.theaters.Find(id);
                db.theaters.Remove(theater);
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
