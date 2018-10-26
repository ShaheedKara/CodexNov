using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sprint1AppDev3A.Models;

namespace Sprint1AppDev3A.Controllers
{
    public class NewVmController : Controller
    {
        //// GET: NewVm
        //[Authorize(Roles = "Agent")]
        //[AcceptVerbs(HttpVerbs.Get)]
        //public ActionResult vm()
        //{
        //    //ApplicationDbContext db = new ApplicationDbContext();

        //    //List<AssignViewModel> vm = new List<AssignViewModel>();

        //    //var Lists = (from A in db.Assigns
        //    //            join T in db.Trucks on A.TrucksID equals T.TruckId
        //    //            join B in db.Bookings on A.BookID equals B.BookingIds
        //    //            join D in db.Drivers on A.DriveID equals D.DriverId
        //    //            select new {A.AssignID,B.refNumber,B.clientname,B.ColCity,B.pickupdate,B.DelCity,B.dropofdate,T.reg,D.DriverFullName,D.contactNumber,D.Email}).ToList();

        //    //foreach(var item in Lists)
        //    //{
        //    //    AssignViewModel avm = new AssignViewModel();

        //    //    avm.AssignID = item.AssignID;
        //    //    avm.refNumber = item.refNumber;
        //    //    avm.ClientName = item.clientname;
        //    //    avm.colCity = item.ColCity;
        //    // //   avm.pickupDate = item.pickupdate;
        //    //    avm.delCity = item.DelCity;
        //    // //   avm.dropoffDate = item.dropofdate;
        //    //    avm.truckReg = item.reg;
        //    //    avm.driverName = item.DriverFullName;
        //    //    avm.driverNum = item.contactNumber;
        //    //    avm.driverEmail = item.Email;

        //    //    vm.Add(avm);

        //    //}


        //    return View(vm);
        }
    }
