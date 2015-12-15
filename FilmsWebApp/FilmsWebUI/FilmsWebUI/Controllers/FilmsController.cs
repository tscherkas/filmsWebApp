using FilmsBLL.Services;
using Ninject;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FilmsWebUI.Controllers
{
    public class FilmsController : Controller
    {
        [Inject]
        public FilmService filmsService { get; set; }
        [Inject]
        public IFilmRecommendService s { get; set; }

        public ViewResult Index(string searchString, int? page)
        {

            if (searchString == null)
            {
                searchString = "";
            }

            ViewBag.SearchString = searchString;
            var films = filmsService.getFilmsIQueryable(searchString);

            int pageSize = 25;
            int pageNumber = (page ?? 1);
            return View(films.ToPagedList(pageNumber, pageSize));
        }
        // GET: Actors/Details/5
        public ActionResult Details(Guid id)
        {
            return View(filmsService.getFilm(id));
        }

        // GET: Actors/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Actors/Create
        [HttpPost]
        public ActionResult Create(FilmsBLL.Models.Film model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }
                return View("Details", filmsService.createOrUpdateFilm(model));
            }
            catch
            {
                return RedirectToAction("Index");
            }
        }

        // GET: Actors/Edit/5
        public ActionResult Edit(Guid id)
        {
            return View(filmsService.getFilm(id));
        }

        // POST: Actors/Edit/5
        [HttpPost]
        public ActionResult Edit(FilmsBLL.Models.Film model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }
                return View("Details", filmsService.createOrUpdateFilm(model));
            }
            catch
            {
                return RedirectToAction("Index");
            }
        }

        public ActionResult Delete(Guid id)
        {
            return View(filmsService.getFilm(id));
        }
        [HttpPost]
        public ActionResult Delete(FilmsBLL.Models.Film model)
        {
            try
            {
                filmsService.deleteFilm(model);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewBag.Message = "Delete is inpossible.";
                return View(model);
            }
        }
        public ActionResult Recommend(Guid id)
        {
            var film = filmsService.getFilm(id);
            var result = s.recommend(new List<FilmsBLL.Models.Film> { film }, new List<FilmsBLL.Models.Film>(), 10);
            return View(result.Select(item => filmsService.getFilm(item.ID)));
        }
    }
}
