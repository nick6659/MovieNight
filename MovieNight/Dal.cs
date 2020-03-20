using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace MovieNight
{
    static class Dal
    {
        private static string connectionString = @"Data Source=NMS-DESKTOP;Initial Catalog=Movie_night;Integrated Security=True";

        public static List<Movie> GetMovies(string search)
        {
            List<Movie> movies = new List<Movie>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Movie WHERE Title LIKE @search", connection);
                SqlParameter parameter = new SqlParameter();
                parameter.ParameterName = "@search";
                parameter.Value = "%" + search + "%";
                cmd.Parameters.Add(parameter);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    int id = (int)reader["MovieID"];
                    string title = (string)reader["Title"];
                    DateTime releaseDate = (DateTime)reader["Release_date"];
                    string genre = (string)reader["Genre"];
                    string description = (string)reader["Description"];

                    Movie movie = new Movie(id, title, releaseDate, genre, description);

                    movies.Add(movie);
                }
            }
            return movies;
        }
        public static List<Actor> GetActors(string search)
        {
            List<Actor> actors = new List<Actor>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Actor WHERE Name LIKE @search", connection);
                SqlParameter parameter = new SqlParameter();
                parameter.ParameterName = "@search";
                parameter.Value = "%" + search + "%";
                cmd.Parameters.Add(parameter);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    string firstName = (string)reader["FirstName"];
                    string lastName = (string)reader["LastName"];

                    Actor a = new Actor(firstName, lastName);

                    actors.Add(a);
                }
            }
            return actors;
        }
        public static List<Movie> GetMoviesByGenre(string search)
        {
            List<Movie> movies = new List<Movie>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {   
                connection.Open();
                SqlCommand cmd = new SqlCommand("SELECT Title FROM Movie INNER JOIN MovieGenre ON[Movie].[ID] = [MovieGenre].[MovieID] INNER JOIN Genre ON[Genre].[ID] = [MovieGenre].[GenreID] WHERE Type LIKE @search", connection);
                SqlParameter parameter = new SqlParameter();
                parameter.ParameterName = "@search";
                parameter.Value = "%" + search + "%";
                cmd.Parameters.Add(parameter);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    string title = (string)reader["Titel"];

                    Movie m = new Movie(title);
                    movies.Add(m);
                }
            }
            return movies;
        }
    }
}
