using Microsoft.AspNet.Identity;
using MyBookingRoles.Models;
using MyBookingRoles.Models.BookingModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace MyBookingRoles.Controllers.BookingsManagement
{
    public class CustomerBookingController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: CustomerBooking
        //Bookings Customer
        public ActionResult customerBookings(string searchWord)
        {
            var id = User.Identity.GetUserName().ToString();
            var mm = db.Bookings.Where(v => v.UserID == id && (v.Status.Contains(searchWord) || searchWord == null)).ToList();
            ViewBag.User = id;
            return View(mm);
        }

        // GET: Bookings/Create
        public ActionResult MakeBooking()
        {
            var BUser = User.Identity.GetUserName().ToString();

            ViewBag.ArtistID = new SelectList(db.Users.Where(a => a.Name == "Artist"), "UserName", "UserName");
            ViewBag.LocationId = new SelectList(db.Locations, "LocationId", "LocationType");
            ViewBag.PackageId = new SelectList(db.Packages, "PackageId", "PackageType");
            ViewBag.ServiceId = new SelectList(db.Services, "ServiceId", "ServiceType");

            Booking bb = new Booking()
            {
                UserID = BUser,
                BookingFee = 100
            };
            return View(bb);
        }

        // POST: Bookings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult MakeBooking(Booking booking)
        {
            //ViewBag.User = User.Identity.GetUserName().ToString();
            if (ModelState.IsValid)
            {
                booking.LocationVenueFee = booking.calcLocationFee();
                booking.PackageCost = booking.calcPackageCost();
                booking.EventFee = booking.calcEventFee();
                booking.Status = "Booked";
                booking.ArtistRateFee = booking.calcArtistFee();
                booking.TotalDue = booking.calcTotalDue();
                booking.Discount = booking.calcDiscount();

                db.Bookings.Add(booking);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ArtistID = new SelectList(db.Users.Where(a => a.Name == "Artist"), "UserName", "UserName");
            ViewBag.LocationId = new SelectList(db.Locations, "LocationId", "LocationType", booking.LocationId);
            ViewBag.PackageId = new SelectList(db.Packages, "PackageId", "PackageType", booking.PackageId);
            ViewBag.ServiceId = new SelectList(db.Services, "ServiceId", "ServiceType", booking.ServiceId);
            return View(booking);
        }

        // GET: Bookings/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Booking booking = db.Bookings.Find(id);
            if (booking == null)
            {
                return HttpNotFound();
            }
            return View(booking);
        }


    }
}