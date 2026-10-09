using JillsMovies.Data;
using JillsMovies.Models;
using System.Data; // behövs för att kunna skriva new Movie

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

            // Skriv ut varje genre – använder ToString() i Genre
            foreach (var movie in repo.GetAllMovies())
            {
                Console.WriteLine(movie);
            }

            Console.WriteLine();
            Console.WriteLine("Ange film-ID: ");
            int movieIdInput = int.Parse(Console.ReadLine()!);

            // Skicka paketet till databasen
            int rowsAffected = repo.DeleteMovie(movieIdInput);

            if (rowsAffected == 1)
            {
                Console.WriteLine($"Filmen togs bort.");
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Ingen film med det Id:t hittades.");
                Console.WriteLine();
            }

            foreach (var movie in repo.GetAllMovies())
            {
                Console.WriteLine(movie);
            }


        }
    }
}
