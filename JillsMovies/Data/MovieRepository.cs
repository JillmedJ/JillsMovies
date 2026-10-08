using System;
using System.Collections.Generic;
using System.Text;
using JillsMovies.Models;
using Microsoft.Data.SqlClient;

namespace JillsMovies.Data
{
    internal class MovieRepository
    {
        private readonly DatabaseConnection _connection;

        public MovieRepository()
        { 
            _connection = new DatabaseConnection();
        }

        public List<Movie>GetAllMovies()
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

    }
}
