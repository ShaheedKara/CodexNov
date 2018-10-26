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
    public class InvoicesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Invoices
        public ActionResult Index()
        {
            return View(db.Invoies.ToList());
        }

        // GET: Invoices/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Invoice invoice = db.Invoies.Find(id);
            if (invoice == null)
            {
                return HttpNotFound();
            }
            return View(invoice);
        }

        // GET: Invoices/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Invoices/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,jobId,name,email,number,pickup,dropoff,ConType,Size,total,vattotal,net")] Invoice invoice)
        {
            if (ModelState.IsValid)
            {


                var Tlist = db.NewBookings.Find(invoice.jobId);
                string iname = " ";
                string iemail = " ";
                string inumber = " ";
                string ipickup = " ";
                string idropoff = " ";
                string icontype = " ";
                string isize = " ";
                double itotal = 0.00;
                //double ievat = 0.00;
                //foreach (var item in Tlist)

                iname = Tlist.clientname;
                iemail = Tlist.email;
                inumber = Tlist.cellnum;
                ipickup = Tlist.Collection;
                idropoff = Tlist.Dropoff;
                icontype = Tlist.ConType;
                isize = Tlist.Size;
                itotal = Tlist.final;
                //ievat = Tlist.evatt;


                invoice.name = iname;
                invoice.email = iemail;
                invoice.number = inumber;
                invoice.pickup = ipickup;
                invoice.dropoff = idropoff;
                invoice.ConType = icontype;
                invoice.Size = isize;
                invoice.total = itotal;
                invoice.vattotal = itotal * 0.15;
                //invoice.net = itotal + invoice.vattotal;

                db.Invoies.Add(invoice);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(invoice);
        }

        // GET: Invoices/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Invoice invoice = db.Invoies.Find(id);
            if (invoice == null)
            {
                return HttpNotFound();
            }
            return View(invoice);
        }

        // POST: Invoices/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,jobId,name,email,number,pickup,dropoff,ConType,Size,total,vattotal,net")] Invoice invoice)
        {
            if (ModelState.IsValid)
            {
                db.Entry(invoice).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(invoice);
        }

        // GET: Invoices/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Invoice invoice = db.Invoies.Find(id);
            if (invoice == null)
            {
                return HttpNotFound();
            }
            return View(invoice);
        }

        // POST: Invoices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Invoice invoice = db.Invoies.Find(id);
            db.Invoies.Remove(invoice);
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
