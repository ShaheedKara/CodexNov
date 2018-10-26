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
    public class NewTrailersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: NewTrailers
        public ActionResult Index()
        {
            return View(db.NewTrailers.ToList());
        }

        // GET: NewTrailers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NewTrailer newTrailer = db.NewTrailers.Find(id);
            if (newTrailer == null)
            {
                return HttpNotFound();
            }
            return View(newTrailer);
        }

        // GET: NewTrailers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: NewTrailers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TrailerId,reg,TrailerSize,Status,Location,Destination")] NewTrailer newTrailer)
        {
            if (ModelState.IsValid)
            {

                db.NewTrailers.Add(newTrailer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(newTrailer);
        }

        // GET: NewTrailers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NewTrailer newTrailer = db.NewTrailers.Find(id);
            if (newTrailer == null)
            {
                return HttpNotFound();
            }
            return View(newTrailer);
        }

        // POST: NewTrailers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TrailerId,reg,TrailerSize,Status,Location,Destination")] NewTrailer newTrailer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(newTrailer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(newTrailer);
        }

        // GET: NewTrailers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NewTrailer newTrailer = db.NewTrailers.Find(id);
            if (newTrailer == null)
            {
                return HttpNotFound();
            }
            return View(newTrailer);
        }

        // POST: NewTrailers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            NewTrailer newTrailer = db.NewTrailers.Find(id);
            db.NewTrailers.Remove(newTrailer);
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
