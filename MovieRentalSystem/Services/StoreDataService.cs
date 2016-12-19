using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MovieRentalSystem.Models;
using System.Data.SqlClient;

namespace MovieRentalSystem.Services
{
	public class StoreDataService
	{
		public static List<Genre> Genres { get; set; }
		public static List<Customer> Customers { get; set; }

		public static List<Genre> GetAllGenres()
		{
			var connectionStrings = @"Server=localhost\SQLEXPRESS;Database=MovieRentalSystem;Trusted_Connection=True;";
			using (var connection = new SqlConnection(connectionStrings))
			{
				using (var cmd = new SqlCommand())
				{
					cmd.Connection = connection;
					cmd.CommandType = System.Data.CommandType.Text;
					cmd.CommandText = @"SELECT Id, Name FROM Genre";

					connection.Open();
					var reader = cmd.ExecuteReader();
					while (reader.Read())
					{
						var id = reader[0];
						var name = reader[1];

						var genre = new Genre
						{
							Id = (int)id,
							Name = name as string
						};
						Genres.Add(genre);
					}
					connection.Close();
				}
				return Genres;
			}
		}
		public static List<Customer> GetAllCustomers()
		{
			var connectionStrings = @"Server=localhost\SQLEXPRESS;Database=MovieRentalSystem;Trusted_Connection=True;";
			using (var connection = new SqlConnection(connectionStrings))
			{
				using (var cmd = new SqlCommand())
				{
					cmd.Connection = connection;
					cmd.CommandType = System.Data.CommandType.Text;
					cmd.CommandText = @"SELECT Id, Name, Email_Addr, Phone FROM Customer";

					connection.Open();
					var reader = cmd.ExecuteReader();
					while (reader.Read())
					{
						var id = reader[0];
						var name = reader[1];
						var email = reader[2];
						var phone = reader[3];

						var customer = new Customer
						{
							Id = (int)id,
							Name = name as string,
							Email = email as string,
							Phone = phone as string
						};
						Customers.Add(customer);
					}
					connection.Close();
				}
				return Customers;
			}
		}
		public static string AddCustomer(Customer newCustomer)
		{
			var connectionStrings = @"Server=localhost\SQLEXPRESS;Database=Libary;Trusted_Connection=True;";
			using (var connection = new SqlConnection(connectionStrings))
			{
				using (var cmd = new SqlCommand())
				{
					cmd.Connection = connection;
					cmd.CommandType = System.Data.CommandType.Text;
					cmd.CommandText = @"INSERT INTO Customer (Name, Email_Addr, Phone)" +
										"Values (@Name, @Author, @Email_Addr, @Phone)";

					cmd.Parameters.AddWithValue("@Name", newCustomer.Name);
					cmd.Parameters.AddWithValue("@Email_Addr", newCustomer.Email);
					cmd.Parameters.AddWithValue("@Phone", newCustomer.Phone);

					connection.Open();
					var rowsAffected = cmd.ExecuteNonQuery();
					connection.Close();

					if (rowsAffected > 0)
					{
						return "Your Book was Added";
					}
					else
					{
						return "The Insert for your Book Failed!";
					}
				}
			}
		}
	}
}