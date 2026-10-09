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

            var app = new Application();
            app.RunMenu();
        }
    }
}
