using MyBookingRoles.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyBookingRoles.Controllers
{
    [Authorize(Roles = "Artist")]
    public class ArtistController : Controller
    {
        private ApplicationDbContext context = new ApplicationDbContext();


        // GET: Artist All Artist Bookings
        public ActionResult DeliveryIndex()
        {
            return View();
        }

        public ActionResult ArtistDashboard()
        {
            return View();
        }
    }
}