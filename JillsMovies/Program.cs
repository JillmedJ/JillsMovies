using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens.Experimental;
using JillsMovies.Data;

namespace JillsMovies
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //var db = new DatabaseConnection();

            //using var connection = db.CreateConnection();
            //connection.Open();

            //Console.WriteLine("Connected!");

            // Skapa repositoryt (det skapar i sin tur DatabaseConnection)
            var repo = new MovieRepository();

            Console.WriteLine("Ange genre: ");
            string genreNameInput = Console.ReadLine()!;

            // Hämta alla filmer från databasen
            var movies = repo.GetMoviesByGenre(genreNameInput);

            if (movies.Count == 0)
            {
                Console.WriteLine("Inga filmer hittades i denna genre.");
            }
            else
            {
                // Skriv ut varje film – använder ToString() i Movie
                foreach (var movie in movies)
                {
                    Console.WriteLine(movie);
                }
            }

            


        }
    }
}
