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
    public class ResourcesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Resources
        public ActionResult Index()
        {
            var resources = db.Resources.Include(r => r.NewDrivers).Include(r => r.NewTrailer).Include(r => r.NewTrucks);
            return View(resources.ToList());
        }

        // GET: Resources/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Resource resource = db.Resources.Find(id);
            if (resource == null)
            {
                return HttpNotFound();
            }
            return View(resource);
        }

        // GET: Resources/Create
        public ActionResult Create()
        {
            ViewBag.DriverId = new SelectList(db.NewDrivers, "DriverId", "Id");
            ViewBag.TrailerId = new SelectList(db.NewTrailers, "TrailerId", "reg");
            ViewBag.TruckId = new SelectList(db.NewTrucks, "TruckId", "make");
            return View();
        }

        // POST: Resources/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,statusResource,TrailerSize,TrailerId,TruckId,DriverId")] Resource resource)
        {
            if (ModelState.IsValid)
            {
                var FindTrailerSize =   db.NewTrailers.Find(resource.TrailerId);
                resource.TrailerSize = FindTrailerSize.TrailerSize;
                resource.statusResource = "Free";
                db.Resources.Add(resource);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DriverId = new SelectList(db.NewDrivers, "DriverId", "Id", resource.DriverId);
            ViewBag.TrailerId = new SelectList(db.NewTrailers, "TrailerId", "reg", resource.TrailerId);
            ViewBag.TruckId = new SelectList(db.NewTrucks, "TruckId", "make", resource.TruckId);
            return View(resource);
        }

        // GET: Resources/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Resource resource = db.Resources.Find(id);
            if (resource == null)
            {
                return HttpNotFound();
            }
            ViewBag.DriverId = new SelectList(db.NewDrivers, "DriverId", "Id", resource.DriverId);
            ViewBag.TrailerId = new SelectList(db.NewTrailers, "TrailerId", "reg", resource.TrailerId);
            ViewBag.TruckId = new SelectList(db.NewTrucks, "TruckId", "make", resource.TruckId);
            return View(resource);
        }

        // POST: Resources/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,statusResource,TrailerSize,TrailerId,TruckId,DriverId")] Resource resource)
        {
            if (ModelState.IsValid)
            {
                db.Entry(resource).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DriverId = new SelectList(db.NewDrivers, "DriverId", "Id", resource.DriverId);
            ViewBag.TrailerId = new SelectList(db.NewTrailers, "TrailerId", "reg", resource.TrailerId);
            ViewBag.TruckId = new SelectList(db.NewTrucks, "TruckId", "make", resource.TruckId);
            return View(resource);
        }

        // GET: Resources/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Resource resource = db.Resources.Find(id);
            if (resource == null)
            {
                return HttpNotFound();
            }
            return View(resource);
        }

        // POST: Resources/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Resource resource = db.Resources.Find(id);
            db.Resources.Remove(resource);
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
