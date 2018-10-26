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
    public class AssignTrailerContsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: AssignTrailerConts
        public ActionResult Index()
        {
            return View(db.AssignTrailerConts.ToList());
        }

        // GET: AssignTrailerConts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AssignTrailerCont assignTrailerCont = db.AssignTrailerConts.Find(id);
            if (assignTrailerCont == null)
            {
                return HttpNotFound();
            }
            return View(assignTrailerCont);
        }

        // GET: AssignTrailerConts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AssignTrailerConts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AssignId,BookingIds,ContainerID,TrailerId")] AssignTrailerCont assignTrailerCont)
        {
            if (ModelState.IsValid)
            {
                db.AssignTrailerConts.Add(assignTrailerCont);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(assignTrailerCont);
        }

        // GET: AssignTrailerConts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AssignTrailerCont assignTrailerCont = db.AssignTrailerConts.Find(id);
            if (assignTrailerCont == null)
            {
                return HttpNotFound();
            }
            return View(assignTrailerCont);
        }

        // POST: AssignTrailerConts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AssignId,BookingIds,ContainerID,TrailerId")] AssignTrailerCont assignTrailerCont)
        {
            if (ModelState.IsValid)
            {
                db.Entry(assignTrailerCont).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(assignTrailerCont);
        }

        // GET: AssignTrailerConts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AssignTrailerCont assignTrailerCont = db.AssignTrailerConts.Find(id);
            if (assignTrailerCont == null)
            {
                return HttpNotFound();
            }
            return View(assignTrailerCont);
        }

        // POST: AssignTrailerConts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AssignTrailerCont assignTrailerCont = db.AssignTrailerConts.Find(id);
            db.AssignTrailerConts.Remove(assignTrailerCont);
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
