using JillsMovies.Data;
using JillsMovies.Models;
using JillsMovies.UI;
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

            var movieMenuCases = new MovieMenuCases();

            var app = new Application(movieMenuCases);

            app.RunMenu();
        }
    }
}
