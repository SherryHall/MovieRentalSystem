using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MovieRentalSystem.Models;

namespace MovieRentalSystem.ViewModels.RentalRecords
{
	public class CreateViewModel
	{
		public RentalLog RentalTrx { get; set; }
		public List<Customer> Customers { get; set; } = new List<Customer>();
		public List<Movie> Movies { get; set; } = new List<Movie>();
	}
}