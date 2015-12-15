using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FilmsBLL.Services;
using FilmsBLL.Models;

namespace FilmsWebUI.Controllers
{
    public class GenresController : Controller
    {
        [Inject]
        public GenreService genreService { get; set; }
        // GET: Genres
        public ActionResult Index()
        {
            return View(genreService.getGenresFromDAL());
        }

        // GET: Genres/Details/5
        public ActionResult Details(int id)
        {
            if (id < 1)
                return RedirectToAction("Index");
            return View(genreService.getGenreFromDAL(id));
        }

        // GET: Genres/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Genres/Create
        [HttpPost]
        public ActionResult Create(FilmsBLL.Models.Genre model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    model = genreService.addOrEditGenreInDAL(model);
                    return View("Details", model);
                }
                return View(model);
            }
            catch
            {
                return RedirectToAction("Index");
            }
        }

        // GET: Genres/Edit/5
        public ActionResult Edit(int id)
        {
            return View(genreService.getGenreFromDAL(id));
        }

        // POST: Genres/Edit/5
        [HttpPost]
        public ActionResult Edit(Genre model)
        {
            try
            {
                // TODO: Add update logic here
                if(!ModelState.IsValid)
                    return View(model);
                return View("Details", genreService.addOrEditGenreInDAL(model));
            }
            catch
            {
                return RedirectToAction("Index");
            }
        }

        // GET: Genres/Delete/5
        public ActionResult Delete(int id)
        {
            return View(genreService.getGenreFromDAL(id));
        }

        // POST: Genres/Delete/5
        [HttpPost]
        public ActionResult Delete(Genre genre)
        {
            try
            {
                // TODO: Add delete logic here
                genreService.deleteGenreFromDAL(genre);
                return RedirectToAction("Index");
            }
            catch
            {
                ViewBag.Message = "Delete is inpossible.";
                return View(genre);
            }
        }
    }
}
