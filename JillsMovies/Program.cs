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

            var repo = new MovieRepository();

            var movies = repo.GetAllMovies();

            foreach (var movie in movies)
            {
                Console.WriteLine(movie);
            }


        }
    }
}
