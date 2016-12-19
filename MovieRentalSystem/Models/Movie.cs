﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieRentalSystem.Models
{
	public class Movie
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public bool IsCheckedOut { get; set; }
		public int Genre_Id { get; set; }
	}
}