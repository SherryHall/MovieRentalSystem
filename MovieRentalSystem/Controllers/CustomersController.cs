using MovieRentalSystem.Models;
using MovieRentalSystem.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MovieRentalSystem.Controllers
{
    public class CustomersController : Controller
    {
        // GET: Customers
        public ActionResult Index()
        {
			var Customers = StoreDataService.GetAllCustomers();
            return View(Customers);
        }

          // GET: Customers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Customers/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
				var newCustomer = new Customer
				{
					Name = collection["name"],
					Email = collection["email"],
					Phone= collection["phone"]
				};

				StoreDataService.AddCustomer(newCustomer);
				return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Customers/Edit/5
        public ActionResult Edit(int id)
        {
			var chgCustomer = StoreDataService.GetOneCustomer(id);
			return View(chgCustomer);
        }

        // POST: Customers/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
				var chgCustomer = new Customer
				{
					Id = id,
					Name = collection["name"],
					Email = collection["email"],
					Phone = collection["phone"]
				};
				StoreDataService.UpdateCustomer(chgCustomer);

				return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Customers/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Customers/Delete/5
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
