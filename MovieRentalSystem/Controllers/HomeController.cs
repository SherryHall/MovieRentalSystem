using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MovieRentalSystem.Controllers
{
	public class HomeController : Controller
	{
		public ActionResult Index()
		{
			return View();
		}

		public ActionResult Return()
		{
			ViewBag.Message = "Return a boox.";

			return View();
		}

		public ActionResult Overdue()
		{
			ViewBag.Message = "List overdue books.";

			return View();
		}
	}
}