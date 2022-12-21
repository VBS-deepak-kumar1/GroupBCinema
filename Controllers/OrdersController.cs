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
    public class OrdersController : Controller
    {


        public DataModel db = new DataModel();

        // GET: orders
        public ActionResult Index(string show_id)

        {
            ViewBag.show_id = show_id;
           
            return View();
        }

        public string SuccessOrder()
        {
            string srt = "your tickets have been confirmed.";
            return srt;
        }

        // GET: orders/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            order order = db.orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // GET: orders/Create
        public ActionResult Create()
        {
            ViewBag.show_id = new SelectList(db.shows, "show_id", "show_id");
            ViewBag.user_id = new SelectList(db.users, "user_id", "user_id");
            if( Session["UserId"] == null)
            {
                return RedirectToAction("Signin","Users");
            }
            else
            {

              
                return View();
            }
        }

        // POST: orders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "order_id,user_id,show_id,total_tickets,total_cost,date,card_id")] order order)
        {
            if (ModelState.IsValid)
            {
                db.orders.Add(order);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.show_id = new SelectList(db.shows, "show_id", "show_id", order.show_id);
            ViewBag.user_id = new SelectList(db.users, "user_id", "user_id", order.user_id);
            return View(order);
        }

        // GET: orders/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            order order = db.orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            // ViewBag.card_id = new SelectList(db.creditcards, "card_id", "card_type", order.card_id);
            ViewBag.show_id = new SelectList(db.shows, "show_id", "show_id", order.show_id);
            ViewBag.user_id = new SelectList(db.users, "user_id", "user_id", order.user_id);
            return View(order);
        }

        // POST: orders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "order_id,user_id,show_id,total_tickets,total_cost,date,card_id")] order order)
        {
            if (ModelState.IsValid)
            {
                db.Entry(order).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            // ViewBag.card_id = new SelectList(db.creditcards, "card_id", "card_type", order.card_id);
            ViewBag.show_id = new SelectList(db.shows, "show_id", "show_id", order.show_id);
            ViewBag.user_id = new SelectList(db.users, "user_id", "user_id", order.user_id);
            return View(order);
        }

        // GET: orders/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            order order = db.orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // POST: orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            order order = db.orders.Find(id);
            db.orders.Remove(order);
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