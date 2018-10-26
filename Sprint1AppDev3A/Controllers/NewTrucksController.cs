using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Sprint1AppDev3A.Models;

namespace Sprint1AppDev3A.Controllers
{
    public class NewTrucksController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: NewTrucks
        public ActionResult Index()
        {
            return View(db.NewTrucks.ToList());
        }

        // GET: NewTrucks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NewTruck newTruck = db.NewTrucks.Find(id);
            if (newTruck == null)
            {
                return HttpNotFound();
            }
            return View(newTruck);
        }

        // GET: NewTrucks/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: NewTrucks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TruckId,make,model,vin,reg,cost,insurance,license,Status,Location,Destination")] NewTruck newTruck)
        {
            if (ModelState.IsValid)
            {

                db.NewTrucks.Add(newTruck);
                db.SaveChanges();
                return RedirectToAction("Index");

                db.NewTrucks.Add(newTruck);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(newTruck);
        }

        // GET: NewTrucks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NewTruck newTruck = db.NewTrucks.Find(id);
            if (newTruck == null)
            {
                return HttpNotFound();
            }
            return View(newTruck);
        }

        // POST: NewTrucks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TruckId,make,model,vin,reg,cost,insurance,license,Status,Location,Destination")] NewTruck newTruck)
        {
            if (ModelState.IsValid)
            {
                db.Entry(newTruck).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(newTruck);
        }

        // GET: NewTrucks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NewTruck newTruck = db.NewTrucks.Find(id);
            if (newTruck == null)
            {
                return HttpNotFound();
            }
            return View(newTruck);
        }

        // POST: NewTrucks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            NewTruck newTruck = db.NewTrucks.Find(id);
            db.NewTrucks.Remove(newTruck);
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
