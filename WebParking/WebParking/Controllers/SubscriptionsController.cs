using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ParkingSystem.Models;

namespace WebParking.Controllers
{
    public class SubscriptionsController : Controller
    {
        private AppContext db = new AppContext();

        // GET: /Subscriptions/
        public ActionResult Index()
        {
            var subscriptions = db.Subscriptions.Include(s => s.Car).Include(s => s.Parking);
            return View(subscriptions.ToList());
        }

        // GET: /Subscriptions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Subscription subscription = db.Subscriptions.Find(id);
            if (subscription == null)
            {
                return HttpNotFound();
            }
            return View(subscription);
        }

        // GET: /Subscriptions/Create
        public ActionResult Create()
        {
            ViewBag.CarId = new SelectList(db.Cars, "Id", "Number");
            ViewBag.ParkingId = new SelectList(db.Parkings, "Id", "Name");
            return View();
        }

        // POST: /Subscriptions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,ExpirtionDate,Cost,PlaceNumber,ParkingId,CarId")] Subscription subscription)
        {
            //if string.IsNullOrEmpty(subscription.)
            if (ModelState.IsValid)
            {
                db.Subscriptions.Add(subscription);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CarId = new SelectList(db.Cars, "Id", "Number", subscription.CarId);
            ViewBag.ParkingId = new SelectList(db.Parkings, "Id", "Name", subscription.ParkingId);
            return View(subscription);
        }

        // GET: /Subscriptions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Subscription subscription = db.Subscriptions.Find(id);
            if (subscription == null)
            {
                return HttpNotFound();
            }
            ViewBag.CarId = new SelectList(db.Cars, "Id", "Number", subscription.CarId);
            ViewBag.ParkingId = new SelectList(db.Parkings, "Id", "Name", subscription.ParkingId);
            return View(subscription);
        }

        // POST: /Subscriptions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,ExpirtionDate,Cost,PlaceNumber,ParkingId,CarId")] Subscription subscription)
        {
            if (ModelState.IsValid)
            {
                db.Entry(subscription).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CarId = new SelectList(db.Cars, "Id", "Number", subscription.CarId);
            ViewBag.ParkingId = new SelectList(db.Parkings, "Id", "Name", subscription.ParkingId);
            return View(subscription);
        }

        // GET: /Subscriptions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Subscription subscription = db.Subscriptions.Find(id);
            if (subscription == null)
            {
                return HttpNotFound();
            }
            return View(subscription);
        }

        // POST: /Subscriptions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Subscription subscription = db.Subscriptions.Find(id);
            db.Subscriptions.Remove(subscription);
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
