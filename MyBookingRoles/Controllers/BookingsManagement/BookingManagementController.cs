﻿using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using MyBookingRoles.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace MyBookingRoles.Controllers.Bookings
{
    [Authorize(Roles = "SuperAdmin")]
    public class BookingManagementController : Controller
    {
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;
        private ApplicationDbContext context;


        public BookingManagementController()
        {
            context = new ApplicationDbContext();
        }

        public BookingManagementController(ApplicationUserManager userManager, ApplicationSignInManager signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;

        }

        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set
            {
                _signInManager = value;
            }
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }
        // GET: BookingManagement
        public ActionResult Index()
        {
            return View();
        }


        //Register Artist roles moved to AppUsers
        // GET: /Account/Register
        //[AllowAnonymous]
        public ActionResult RegisterArtist()
        {
            return View();
        }

        //
        // POST: /Account/Register
        [HttpPost]
        //[AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> RegisterArtist(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {

                string cust = "Artist";
                var user = new ApplicationUser { Name = cust, UserName = model.Email, Email = model.Email, DateCreated = DateTime.Now };
                var result = await UserManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    //await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);
                    //
                    await UserManager.AddToRolesAsync(user.Id, cust);
                    SignInManager.Dispose();
                    // For more information on how to enable account confirmation and password reset please visit https://go.microsoft.com/fwlink/?LinkID=320771
                    // Send an email with this link
                    // string code = await UserManager.GenerateEmailConfirmationTokenAsync(user.Id);
                    // var callbackUrl = Url.Action("ConfirmEmail", "Account", new { userId = user.Id, code = code }, protocol: Request.Url.Scheme);
                    // await UserManager.SendEmailAsync(user.Id, "Confirm your account", "Please confirm your account by clicking <a href=\"" + callbackUrl + "\">here</a>");

                    //I Changed from "Index", "Home"

                    return RedirectToAction("Index", "AppUsers");
                }
                //AddErrors(result);
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }


        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }
    }
}