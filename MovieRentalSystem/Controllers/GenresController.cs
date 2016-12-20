using MovieRentalSystem.Models;
using MovieRentalSystem.Services;
using MovieRentalSystem.ViewModels.Genres;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MovieRentalSystem.Controllers
{


	public class GenresController : Controller
    {
		public static List<Genre> Genres { get; set; } = new List<Genre>();

		// GET: Genres
		public ActionResult Index()
        {
			var Genres = StoreDataService.GetAllGenres();
            return View(Genres);
        }

 
        // GET: Genres/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Genres/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
				var newGenre = new Genre
				{
					Name = collection["name"]
				};
				StoreDataService.AddGenre(newGenre);

				return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Genres/Edit/5
        public ActionResult Edit(int id)
        {
			var chgGenre = StoreDataService.GetOneGenre(id);
            return View(chgGenre);
        }

        // POST: Genres/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
				var chgGenre = new Genre
				{
					Id = id,
					Name = collection["name"]
				};
				StoreDataService.UpdateGenre(chgGenre);

				return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Genres/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Genres/Delete/5
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
