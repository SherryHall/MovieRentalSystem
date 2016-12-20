using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MovieRentalSystem.ViewModels;
using MovieRentalSystem.Services;

namespace MovieRentalSystem.Controllers
{
    public class RentalRecordsController : Controller
    {
        // GET: RentalRecords
        public ActionResult Index()
        {
            return View();
        }

        // GET: RentalRecords/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: RentalRecords/Create
        public ActionResult Create()
        {
			var rentalViewInfo = new ViewModels.RentalRecords.CreateViewModel();
			rentalViewInfo.Customers = StoreDataService.GetAllCustomers();
			rentalViewInfo.Movies = StoreDataService.GetAllMovies();

			return View(rentalViewInfo);
        }

        // POST: RentalRecords/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: RentalRecords/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: RentalRecords/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: RentalRecords/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: RentalRecords/Delete/5
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
