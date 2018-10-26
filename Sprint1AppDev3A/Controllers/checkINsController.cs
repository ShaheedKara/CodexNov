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
    public class checkINsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: checkINs
        public ActionResult Index()
        {
            return View(db.Checkin.ToList());
        }

        // GET: checkINs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            checkIN checkIN = db.Checkin.Find(id);
            if (checkIN == null)
            {
                return HttpNotFound();
            }
            return View(checkIN);
        }

        // GET: checkINs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: checkINs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,CheckInDate,name")] checkIN checkIN)
        {
            if (ModelState.IsValid)
            {

                var Tlist = db.NewDrivers.Find(checkIN.ID);
                string iname = " ";

                iname = Tlist.DriverFullName;
                checkIN.name = iname;
                checkIN.CheckInDate = System.DateTime.UtcNow;
                db.Checkin.Add(checkIN);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(checkIN);
        }

        // GET: checkINs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            checkIN checkIN = db.Checkin.Find(id);
            if (checkIN == null)
            {
                return HttpNotFound();
            }
            return View(checkIN);
        }

        // POST: checkINs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,CheckInDate,name")] checkIN checkIN)
        {
            if (ModelState.IsValid)
            {
                db.Entry(checkIN).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(checkIN);
        }

        // GET: checkINs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            checkIN checkIN = db.Checkin.Find(id);
            if (checkIN == null)
            {
                return HttpNotFound();
            }
            return View(checkIN);
        }

        // POST: checkINs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            checkIN checkIN = db.Checkin.Find(id);
            db.Checkin.Remove(checkIN);
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
