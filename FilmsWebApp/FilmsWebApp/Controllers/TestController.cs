using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FilmsBLL.Models;

namespace FilmsWebApp.Controllers
{
    public class TestController : Controller
    {
        // GET: Test
        public ActionResult Index()
        {
            var service = new FilmsBLL.Class1();
            return View(service.getFilm());
        }
    }
}