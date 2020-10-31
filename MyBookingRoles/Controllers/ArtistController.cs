﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyBookingRoles.Controllers
{
    [Authorize(Roles = "Artist")]
    public class ArtistController : Controller
    {
        // GET: Artist
        public ActionResult ArtistDashboard()
        {
            return View();
        }
    }
}