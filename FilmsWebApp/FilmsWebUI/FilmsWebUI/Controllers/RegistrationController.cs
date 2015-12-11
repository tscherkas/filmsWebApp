using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FilmsBLL.Models;

namespace FilmsWebUI.Controllers
{
    public class RegistrationController : Controller
    {
        // GET: Registration
        public ActionResult Index()
        {
            return RedirectToAction("Login");
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Models.UserModel m)
        {
            if (ModelState.IsValid)
                return View("AccountInfo");
            else
                return View(m);
        }



        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(Models.UserModel m)
        {
            if (ModelState.IsValid)
                return RedirectToAction("Login");
            else
                return View(m);
        }

    }
}
