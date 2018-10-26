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
    public class RateUsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: tblRates
        public ActionResult Index()
        {
            return View(db.RateUs.ToList());

        }

        // GET: tblRates/Details/5 
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RateUs tblRates = db.RateUs.Find(id);
            if (tblRates == null)
            {
                return HttpNotFound();
            }
            return View(tblRates);
        }

        // GET: tblRates/Create
        public ActionResult Create()
        {
            //string name = db.tblrate.Find(User.Identity.Name).ToString(); ;
            //if (User.Identity.Name == name)
            //{
            //    Response.Redirect("~/Home/index");
            //}
            return View();
        }

        // POST: tblRates/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "name,rating")] RateUs Rate)
        {
            if (ModelState.IsValid)
            {
                if (Request.Form["one"] != null)
                {
                    string name = User.Identity.Name;
                    int rate = 1;
                    Rate.name = name;
                    Rate.rating = rate;
                    db.RateUs.Add(Rate);
                    db.SaveChanges();
                    Response.Redirect("Thanks2");
                }
                else if (Request.Form["two"] != null)
                {
                    string name = User.Identity.Name;
                    int rate = 2;
                    Rate.name = name;
                    Rate.rating = rate;
                    db.RateUs.Add(Rate);
                    db.SaveChanges();
                    Response.Redirect("Thanks2");
                }
                else if (Request.Form["three"] != null)
                {
                    string name = User.Identity.Name;
                    int rate = 3;
                    Rate.name = name;
                    Rate.rating = rate;
                    db.RateUs.Add(Rate);
                    db.SaveChanges();
                    Response.Redirect("Thanks2");
                }
                else if (Request.Form["four"] != null)
                {
                    string name = User.Identity.Name;
                    int rate = 4;
                    Rate.name = name;
                    Rate.rating = rate;
                    db.RateUs.Add(Rate);
                    db.SaveChanges();
                    Response.Redirect("Thanks");
                }
                else if (Request.Form["five"] != null)
                {
                    string name = User.Identity.Name;
                    int rate = 5;
                    Rate.name = name;
                    Rate.rating = rate;
                    db.RateUs.Add(Rate);
                    db.SaveChanges();
                    Response.Redirect("Thanks");
                }


                return RedirectToAction("Index");
            }

            return View(Rate);
        }
        public ActionResult Thanks()
        {

            return View();
        }
        public ActionResult Thanks2()
        {
            return View();
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