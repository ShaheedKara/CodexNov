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
    public class DeliveryNotesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: DeliveryNotes
        public ActionResult Index()
        {
            return View(db.DeliveryNotes.ToList());
        }

        // GET: DeliveryNotes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DeliveryNote deliveryNote = db.DeliveryNotes.Find(id);
            if (deliveryNote == null)
            {
                return HttpNotFound();
            }
            return View(deliveryNote);
        }

        // GET: DeliveryNotes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DeliveryNotes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "NoteID,dateCreated,clientname,ConType,Size,specInstruct,Dropoff")] DeliveryNote deliveryNote)
        {
            if (ModelState.IsValid)
            {
                db.DeliveryNotes.Add(deliveryNote);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(deliveryNote);
        }

        // GET: DeliveryNotes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DeliveryNote deliveryNote = db.DeliveryNotes.Find(id);
            if (deliveryNote == null)
            {
                return HttpNotFound();
            }
            return View(deliveryNote);
        }

        // POST: DeliveryNotes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "NoteID,dateCreated,clientname,ConType,Size,specInstruct,Dropoff")] DeliveryNote deliveryNote)
        {
            if (ModelState.IsValid)
            {
                db.Entry(deliveryNote).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(deliveryNote);
        }

        // GET: DeliveryNotes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DeliveryNote deliveryNote = db.DeliveryNotes.Find(id);
            if (deliveryNote == null)
            {
                return HttpNotFound();
            }
            return View(deliveryNote);
        }

        // POST: DeliveryNotes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DeliveryNote deliveryNote = db.DeliveryNotes.Find(id);
            db.DeliveryNotes.Remove(deliveryNote);
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
