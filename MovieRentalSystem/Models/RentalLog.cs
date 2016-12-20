using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieRentalSystem.Models
{
	public class RentalLog
	{
		public int Id { get; set; }
		public int Customer_Id { get; set; }
		public int Movie_Id { get; set; }
		public DateTime RentalDate { get; set; }
		public DateTime DueDate { get; set; }
		public string ReturnDate { get; set; }
	}
}