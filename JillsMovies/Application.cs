using JillsMovies.Data;
using JillsMovies.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace JillsMovies
{
    internal class Application
    {
        private readonly MovieMenuCases _movieMenuCases;

        public Application(MovieMenuCases movieMenuCases)
        { 
            _movieMenuCases = movieMenuCases;
        }

        internal void RunMenu()
        {
            bool running = true;

            while (running)
            {
                Console.WriteLine();
                Console.WriteLine("--- Filmregister ---");
                Console.WriteLine();

                Console.WriteLine("1. Visa alla filmer");
                Console.WriteLine("2. Sök filmer efter genre");
                Console.WriteLine("3. Lägg till film");
                Console.WriteLine("4. Ta bort film");
                Console.WriteLine("0. Avsluta");
                Console.Write("Välj: ");

                string? choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        _movieMenuCases.ShowAllMovies();
                        break;
                    case "2":
                        _movieMenuCases.SearchByGenre();
                        break;
                    case "3":
                        _movieMenuCases.AddMovie();
                        break;
                    case "4":
                        _movieMenuCases.DeleteMovie();
                        break;
                    case "0":
                        running = false;
                        Console.WriteLine("Hej då!");
                        break;

                    default:
                        Console.WriteLine("Ogiltigt val, försök igen.");
                        break;
                }
            }
        }
    }
}
