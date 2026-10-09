using JillsMovies.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace JillsMovies.Data
{
    internal class MovieRepository
    {
        private readonly DatabaseConnection _connection;

        public MovieRepository()
        {
            _connection = new DatabaseConnection();
        }

        public List<Movie> GetAllMovies()
        {
            var movies = new List<Movie>();

            string sqlMovieInfo = @"
            SELECT m.Id, m.Title, m.ReleaseYear, m.GenreId, g.GenreName
            FROM Movies m
            JOIN Genres g ON m.GenreId = g.Id
            ORDER BY m.Title";

            using var connection = _connection.CreateConnection();
            connection.Open();

            using var sqlCommand = new SqlCommand(sqlMovieInfo, connection);

            using var reader = sqlCommand.ExecuteReader();

            while (reader.Read())
            {
                var movie = new Movie()
                {
                    Id = reader.GetInt32(0),
                    Title = reader.GetString(1),
                    ReleaseYear = reader.GetInt32(2),
                    GenreId = reader.GetInt32(3),
                    GenreName = reader.GetString(4)
                };

                movies.Add(movie); // Lägg till så att den enskilda filmens med listat innehåll visas
            }

            return movies; // Visa alla filmer med listat innehåll
        }

        public List<Movie> GetMoviesByGenre(string genreName)
        {
            var movies = new List<Movie>();

            string sqlGenreGroup = @"
            SELECT m.Id, m.Title, m.ReleaseYear, m.GenreId, g.GenreName
            FROM Movies m
            JOIN Genres g ON m.GenreId = g.Id
            WHERE g.GenreName = @GenreName
            ORDER BY m.Title";

            using var connection = _connection.CreateConnection();
            connection.Open();

            using var sqlCommand = new SqlCommand(sqlGenreGroup, connection);

            sqlCommand.Parameters.AddWithValue("@GenreName", genreName); // Skydd mot felaktigt input, ex DROP TAbLE 

            using var reader = sqlCommand.ExecuteReader();

            while (reader.Read())
            {
                var movie = new Movie()
                {
                    Id = reader.GetInt32(0),
                    Title = reader.GetString(1),
                    ReleaseYear = reader.GetInt32(2),
                    GenreId = reader.GetInt32(3),
                    GenreName = reader.GetString(4)
                };

                movies.Add(movie); 

            }

            return movies;

        }

        public List<Genre> GetAllGenres()
        {
            var genres = new List<Genre>();

            string sqlAllGenres = @"
            SELECT g.Id, g.GenreName
            FROM Genres g
            ORDER BY g.GenreName";

            using var connection = _connection.CreateConnection();
            connection.Open();

            using var sqlCommand = new SqlCommand(sqlAllGenres, connection);

            using var reader = sqlCommand.ExecuteReader();

            while (reader.Read())
            {
                var genre = new Genre()
                {
                    Id = reader.GetInt32(0),
                    GenreName = reader.GetString(1)
                };

                genres.Add(genre); // Lägg till så att den enskilda genren med listat innehåll visas
            }

            return genres; // Visa alla filmer med listat innehåll
        }


        public int AddMovie(Movie movie) // Returnerar antal rader som lades till (1 = lyckades)
        {
            string sqlAddMovie = @"
                                INSERT INTO Movies(Title, ReleaseYear, GenreId)
                                VALUES(@Title, @ReleaseYear, @GenreId)";

            using var connection = _connection.CreateConnection();
            connection.Open();

            using var sqlCommand = new SqlCommand(sqlAddMovie, connection);

            sqlCommand.Parameters.AddWithValue("@Title", movie.Title); // Skydd mot felaktigt input, ex DROP TAbLE 
            sqlCommand.Parameters.AddWithValue("@ReleaseYear", movie.ReleaseYear); // Skydd mot felaktigt input, ex DROP TAbLE 
            sqlCommand.Parameters.AddWithValue("@GenreId", movie.GenreId); // Skydd mot felaktigt input, ex DROP TAbLE 

            int rowsAffected = sqlCommand.ExecuteNonQuery(); // 1 = en ny rad skapades i databasen

            return rowsAffected; // ExecuteNonQuery = ändra data.Returnerar antal påverkade rader.
        }

        public int DeleteMovie(int inputMovieId)
        { 
            string sqlDeleteMovie = @"DELETE
                                    FROM Movies
                                    Where Id = @Id";

            using var connection = _connection.CreateConnection();
            connection.Open();

            using var sqlCommand = new SqlCommand(sqlDeleteMovie, connection);

            sqlCommand.Parameters.AddWithValue("@Id", inputMovieId); // Skydd mot felaktigt input, ex DROP TAbLE 

            int rowsAffected = sqlCommand.ExecuteNonQuery(); // 1 = en ny rad skapades i databasen

            return rowsAffected; // ExecuteNonQuery = ändra data.Returnerar antal påverkade rader.
        }
    }
}
