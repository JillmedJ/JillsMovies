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

            //Console.WriteLine("Ange genre: ");
            //string genreNameInput = Console.ReadLine()!;

            // Hämta alla genrer från databasen
            var genres = repo.GetAllGenres();

           
                // Skriv ut varje genre – använder ToString() i Genre
                foreach (var genre in genres)
                {
                    Console.WriteLine(genre);
                }
            

            


        }
    }
}
