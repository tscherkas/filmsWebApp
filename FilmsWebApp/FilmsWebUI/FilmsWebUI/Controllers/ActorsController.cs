using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FilmsWebUI.Models;
using FilmsBLL.Services;
using PagedList;
using Ninject;

namespace FilmsWebUI.Controllers
{
    public class ActorsController : Controller
    {
        [Inject]
        public ActorsService actorsService { get; set; }
        // GET: Actors
        public ActionResult Index(int? page)
        {
            var actors = actorsService.getActorsFromDAL(); 

            var pageNumber = page ?? 1; 
            var onePageOfActors = actors.ToPagedList(pageNumber, 25); 

            ViewBag.OnePageOfProducts = onePageOfActors;
            return View();
        }

        // GET: Actors/Details/5
        public ActionResult Details(Guid id)
        {            
            return View(actorsService.getActorFromDAL(id));
        }

        // GET: Actors/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Actors/Create
        [HttpPost]
        public ActionResult Create(FilmsBLL.Models.Actor model)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    return RedirectToAction("Index");
                }
                return View("Details", actorsService.addOrEditActorInDAL(model));
            }
            catch
            {
                return RedirectToAction("Index");
            }
        }

        // GET: Actors/Edit/5
        public ActionResult Edit(Guid id)
        {
            return View(actorsService.getActorFromDAL(id));
        }

        // POST: Actors/Edit/5
        [HttpPost]
        public ActionResult Edit(FilmsBLL.Models.Actor model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return RedirectToAction("Index");
                }
                return View("Details", actorsService.addOrEditActorInDAL(model));
            }
            catch
            {
                return RedirectToAction("Index");
            }
        }

        // GET: Actors/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Actors/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
