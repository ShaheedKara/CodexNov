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
    public class NewContainersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: NewContainersC:\Users\Appa Kara\Desktop\Appdev project Files\Sha Shed\sprint3-2ND DEPLOY\Deploy Version\Sprint1AppDev3A\Controllers\NewContainersController.cs
        public ActionResult Index()
        {
            return View(db.NewContainers.ToList());
        }

        // GET: NewContainers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NewContainer newContainer = db.NewContainers.Find(id);
            if (newContainer == null)
            {
                return HttpNotFound();
            }
            return View(newContainer);
        }

        // GET: NewContainers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: NewContainers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ContainerID,ContainerNumber,ContainerSize,Status,Location,Destination,PickUp,DeadLine,ActualDropOff")] NewContainer newContainer)
        {
            if (ModelState.IsValid)
            {
                db.NewContainers.Add(newContainer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(newContainer);
        }

        // GET: NewContainers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NewContainer newContainer = db.NewContainers.Find(id);
            if (newContainer == null)
            {
                return HttpNotFound();
            }
            return View(newContainer);
        }

        // POST: NewContainers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ContainerID,ContainerNumber,ContainerSize,Status,Location,Destination,PickUp,DeadLine,ActualDropOff")] NewContainer newContainer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(newContainer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(newContainer);
        }

        // GET: NewContainers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NewContainer newContainer = db.NewContainers.Find(id);
            if (newContainer == null)
            {
                return HttpNotFound();
            }
            return View(newContainer);
        }

        // POST: NewContainers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            NewContainer newContainer = db.NewContainers.Find(id);
            db.NewContainers.Remove(newContainer);
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
