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
    public class CarsController : Controller
    {
        private AppContext db = new AppContext();

        // GET: /Cars/
        public ActionResult Index(string sortOrder)
        {
            //12
            ViewBag.NumberSortParm = String.IsNullOrEmpty(sortOrder) ? "Number" : "";
            ViewBag.MarkSortParm = String.IsNullOrEmpty(sortOrder) ? "Mark" : "";
            var cars = from carOrd in db.Cars
                       select carOrd;

            cars = db.Cars.Include(c => c.Employee);
            switch (sortOrder)
            {
                case "Number desc":
                    cars = cars.OrderByDescending(carOrd => carOrd.Number);
                    break;
                case "Number":
                    cars = cars.OrderBy(carOrd => carOrd.Number);
                    break;
                case "Mark":
                    cars = cars.OrderBy(carOrd => carOrd.Mark);
                    break;
                case "Mark desc":
                    cars = cars.OrderByDescending(carOrd => carOrd.Mark);
                    break;
                default:
                    cars = cars.OrderBy(carOrd => carOrd.Id);
                    break;
            }
            //12
            return View(cars.ToList());
        }

        // GET: /Cars/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Car car = db.Cars.Find(id);
            if (car == null)
            {
                return HttpNotFound();
            }
            return View(car);
        }

        // GET: /Cars/Create
        public ActionResult Create()
        {
            ViewBag.EmployeeId = new SelectList(db.Employees, "Id", "Name");
            return View();
        }

        // POST: /Cars/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Number,Mark,Model,EmployeeId")] Car car)
        {
            if (ModelState.IsValid)
            {
                db.Cars.Add(car);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EmployeeId = new SelectList(db.Employees, "Id", "Name", car.EmployeeId);
            return View(car);
        }

        // GET: /Cars/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Car car = db.Cars.Find(id);
            if (car == null)
            {
                return HttpNotFound();
            }
            ViewBag.EmployeeId = new SelectList(db.Employees, "Id", "Name", car.EmployeeId);
            return View(car);
        }

        // POST: /Cars/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Number,Mark,Model,EmployeeId")] Car car)
        {
            if (ModelState.IsValid)
            {
                db.Entry(car).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EmployeeId = new SelectList(db.Employees, "Id", "Name", car.EmployeeId);
            return View(car);
        }

        // GET: /Cars/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Car car = db.Cars.Find(id);
            if (car == null)
            {
                return HttpNotFound();
            }
            return View(car);
        }

        // POST: /Cars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Car car = db.Cars.Find(id);
            db.Cars.Remove(car);
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
