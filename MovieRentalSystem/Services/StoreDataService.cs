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
		public static List<Genre> Genres { get; set; } = new List<Genre>();
		public static List<Customer> Customers { get; set; } = new List<Customer>();
		public static List<Movie> Movies { get; set; } = new List<Movie>();

		public static List<Genre> GetAllGenres()
		{
			Genres.Clear();
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
				Genres = Genres.OrderBy(g => g.Name).ToList();
				return Genres;
			}
		}
		public static Genre GetOneGenre(int getId)
		{
			Genres.Clear();
			var connectionStrings = @"Server=localhost\SQLEXPRESS;Database=MovieRentalSystem;Trusted_Connection=True;";
			using (var connection = new SqlConnection(connectionStrings))
			{
				using (var cmd = new SqlCommand())
				{
					cmd.Connection = connection;
					cmd.CommandType = System.Data.CommandType.Text;
					cmd.CommandText = $@"SELECT Id, Name FROM Genre WHERE Id = @Id";
					cmd.Parameters.AddWithValue("@Id", getId);

					var getGenre = new Genre();
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
						getGenre = genre;
					}
					connection.Close();
					return getGenre;
				}
			}
		}
		public static void AddGenre(Genre newGenre)
		{
			var connectionStrings = @"Server=localhost\SQLEXPRESS;Database=MovieRentalSystem;Trusted_Connection=True;";
			using (var connection = new SqlConnection(connectionStrings))
			{
				using (var cmd = new SqlCommand())
				{
					cmd.Connection = connection;
					cmd.CommandType = System.Data.CommandType.Text;
					cmd.CommandText = @"INSERT INTO Genre (Name)" +
										"Values (@Name)";

					cmd.Parameters.AddWithValue("@Name", newGenre.Name);

					connection.Open();
					var rowsAffected = cmd.ExecuteNonQuery();
					connection.Close();
				}
			}
		}
		public static void UpdateGenre(Genre chgGenre)
		{
			var connectionStrings = @"Server=localhost\SQLEXPRESS;Database=MovieRentalSystem;Trusted_Connection=True;";
			using (var connection = new SqlConnection(connectionStrings))
			{
				using (var cmd = new SqlCommand())
				{
					cmd.Connection = connection;
					cmd.CommandType = System.Data.CommandType.Text;
					cmd.CommandText = @"UPDATE Genre SET Name = @Name WHERE Id = @id";

					cmd.Parameters.AddWithValue("@Name", chgGenre.Name);
					cmd.Parameters.AddWithValue("@Id", chgGenre.Id);

					connection.Open();
					var rowsAffected = cmd.ExecuteNonQuery();
					connection.Close();
				}
			}
		}

		public static void DeleteGenre(int id)
		{
			var connectionStrings = @"Server=localhost\SQLEXPRESS;Database=MovieRentalSystem;Trusted_Connection=True;";
			using (var connection = new SqlConnection(connectionStrings))
			{
				using (var cmd = new SqlCommand())
				{
					cmd.Connection = connection;
					cmd.CommandType = System.Data.CommandType.Text;
					cmd.CommandText = @"DELETE FROM Genre WHERE Id = @id";

					cmd.Parameters.AddWithValue("@Id", id);

					connection.Open();
					var rowsAffected = cmd.ExecuteNonQuery();
					connection.Close();
				}
			}
		}

		public static List<Customer> GetAllCustomers()
		{
			Customers.Clear();
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
				Customers = Customers.OrderBy(g => g.Name).ToList();
				return Customers;
			}
		}

		public static Customer GetOneCustomer(int getId)
		{
			Customers.Clear();
			var connectionStrings = @"Server=localhost\SQLEXPRESS;Database=MovieRentalSystem;Trusted_Connection=True;";
			using (var connection = new SqlConnection(connectionStrings))
			{
				using (var cmd = new SqlCommand())
				{
					cmd.Connection = connection;
					cmd.CommandType = System.Data.CommandType.Text;
					cmd.CommandText = @"SELECT Id, Name, Email_Addr, Phone FROM Customer WHERE Id = @Id";
					cmd.Parameters.AddWithValue("@Id", getId);
					var getCustomer = new Customer();
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
						getCustomer = customer;
					}
					connection.Close();
					return getCustomer;
				}
			}
		}
		public static void AddCustomer(Customer newCustomer)
		{
			var connectionStrings = @"Server=localhost\SQLEXPRESS;Database=MovieRentalSystem;Trusted_Connection=True;";
			using (var connection = new SqlConnection(connectionStrings))
			{
				using (var cmd = new SqlCommand())
				{
					cmd.Connection = connection;
					cmd.CommandType = System.Data.CommandType.Text;
					cmd.CommandText = @"INSERT INTO Customer (Name, Email_Addr, Phone)" +
										"Values (@Name, @Email_Addr, @Phone)";

					cmd.Parameters.AddWithValue("@Name", newCustomer.Name);
					cmd.Parameters.AddWithValue("@Email_Addr", newCustomer.Email);
					cmd.Parameters.AddWithValue("@Phone", newCustomer.Phone);

					connection.Open();
					var rowsAffected = cmd.ExecuteNonQuery();
					connection.Close();

				}
			}
		}
		public static void UpdateCustomer(Customer chgCustomer)
		{
			var connectionStrings = @"Server=localhost\SQLEXPRESS;Database=MovieRentalSystem;Trusted_Connection=True;";
			using (var connection = new SqlConnection(connectionStrings))
			{
				using (var cmd = new SqlCommand())
				{
					cmd.Connection = connection;
					cmd.CommandType = System.Data.CommandType.Text;
					cmd.CommandText = @"UPDATE Customer SET Name = @Name, Email_Addr = @Email_Addr, Phone=@Phone WHERE Id = @id";

					cmd.Parameters.AddWithValue("@Name", chgCustomer.Name);
					cmd.Parameters.AddWithValue("@Email_Addr", chgCustomer.Email);
					cmd.Parameters.AddWithValue("@Phone", chgCustomer.Phone);
					cmd.Parameters.AddWithValue("@Id", chgCustomer.Id);

					connection.Open();
					var rowsAffected = cmd.ExecuteNonQuery();
					connection.Close();
				}
			}
		}

		public static void DeleteCustomer(int id)
		{
			var connectionStrings = @"Server=localhost\SQLEXPRESS;Database=MovieRentalSystem;Trusted_Connection=True;";
			using (var connection = new SqlConnection(connectionStrings))
			{
				using (var cmd = new SqlCommand())
				{
					cmd.Connection = connection;
					cmd.CommandType = System.Data.CommandType.Text;
					cmd.CommandText = @"DELETE FROM Customer WHERE Id = @id";

					cmd.Parameters.AddWithValue("@Id", id);

					connection.Open();
					var rowsAffected = cmd.ExecuteNonQuery();
					connection.Close();
				}
			}
		}

		public static List<Movie> GetAllMovies()
		{
			Movies.Clear();
			var connectionStrings = @"Server=localhost\SQLEXPRESS;Database=MovieRentalSystem;Trusted_Connection=True;";
			using (var connection = new SqlConnection(connectionStrings))
			{
				using (var cmd = new SqlCommand())
				{
					cmd.Connection = connection;
					cmd.CommandType = System.Data.CommandType.Text;
					cmd.CommandText = @"SELECT Id, Name, Description, IsCheckedOut, Genre_Id FROM Movies";

					connection.Open();
					var reader = cmd.ExecuteReader();
					while (reader.Read())
					{
						var id = reader[0];
						var name = reader[1];
						var description = reader[2];
						var isCheckedOut = reader.GetBoolean(3);
						var genre_id = reader[4];

						var movie = new Movie
						{
							Id = (int)id,
							Name = name as string,
							Description = description as string,
							IsCheckedOut = isCheckedOut,
							Genre_Id = (int)genre_id

						};
						Movies.Add(movie);
					}
					connection.Close();
				}
				Movies = Movies.OrderBy(g => g.Name).ToList();
				return Movies;
			}
		}
	}
}