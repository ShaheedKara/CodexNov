using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Sprint1AppDev3A.Models;
using System.Globalization;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Sprint1AppDev3A.Controllers
{
    public class QuotesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Quotes
        public ActionResult Index()
        {
            var quote = db.quote.Include(q => q.RFQs);
            return View(quote.ToList());
        }

        // GET: Quotes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Quotes quotes = db.quote.Find(id);
            if (quotes == null)
            {
                return HttpNotFound();
            }
            return View(quotes);
        }

        // GET: Quotes/Create
        public ActionResult Create()
        {
            ViewBag.QuoteRequestNo = new SelectList(db.rfq, "QuoteRequestNo", "Email");
            return View();
        }

        // POST: Quotes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "quoteNo,tWage,TollFees,PettyCash,FuelPrice,finalamt,QuoteRequestNo,testtext, two")] Quotes quotes)
        {
            if (ModelState.IsValid)
            {
                string neww = quotes.testtext;
                neww = neww.Replace("km", "");
                neww = neww.Replace(",", "");
                neww = neww.Trim();

                string dist = neww;
                quotes.two = Convert.ToDouble(neww, CultureInfo.InvariantCulture);
                quotes.two = Math.Round(quotes.two);


                quotes.finalamt = (quotes.calcExp() * (quotes.two * 40/100));


                db.quote.Add(quotes);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.QuoteRequestNo = new SelectList(db.rfq, "QuoteRequestNo", "Email", quotes.QuoteRequestNo);
            return View(quotes);
        }

        // GET: Quotes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Quotes quotes = db.quote.Find(id);
            if (quotes == null)
            {
                return HttpNotFound();
            }
            ViewBag.QuoteRequestNo = new SelectList(db.rfq, "QuoteRequestNo", "Email", quotes.QuoteRequestNo);
            return View(quotes);
        }

        // POST: Quotes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "quoteNo,tWage,TollFees,PettyCash,FuelPrice,Texpenses,finalamt,QuoteRequestNo")] Quotes quotes)
        {
            if (ModelState.IsValid)
            {
                quotes.finalamt = quotes.calcExp();
                db.Entry(quotes).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.QuoteRequestNo = new SelectList(db.rfq, "QuoteRequestNo", "Email", quotes.QuoteRequestNo);
            return View(quotes);
        }

        // GET: Quotes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Quotes quotes = db.quote.Find(id);
            if (quotes == null)
            {
                return HttpNotFound();
            }
            return View(quotes);
        }

        // POST: Quotes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Quotes quotes = db.quote.Find(id);
            db.quote.Remove(quotes);
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
        public ActionResult vm()
        {
            List<Vm> vmlist = new List<Vm>();
            var details = (from a in db.rfq
                           join b in db.quote on a.QuoteRequestNo equals b.QuoteRequestNo
                           select new
                           {
                               a.Email,
                               a.Instruct,
                               a.price,
                               a.SysDate,
                               a.DelCity,
                               a.DelArea,
                               a.DelStreetName,
                               a.DelStreetNum,
                               b.finalamt
                           }).ToList();
            foreach (var item in details)
            {
                Vm obj = new Vm();
                obj.Email = item.Email;
                obj.date = item.SysDate;
                obj.Instructions = item.Instruct;
                obj.Deladdress = item.DelStreetNum + " " + item.DelStreetName + "  " + item.DelCity + " " + item.DelArea;
                obj.endAmt = item.price + item.finalamt;
                vmlist.Add(obj);
            }
            return View(vmlist);
        }
    }
}
