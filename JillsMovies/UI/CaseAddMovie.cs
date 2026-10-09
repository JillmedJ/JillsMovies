//using JillsMovies.Data;
//using JillsMovies.Models;
//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace JillsMovies.UI
//{
//    internal class CaseAddMovie
//    {

//        // Skapa repositoryt (det skapar i sin tur DatabaseConnection)
//        var repo = new MovieRepository();

//            // Skriv ut varje genre – använder ToString() i Genre
//            foreach (var genre in repo.GetAllGenres())
//            {
//                Console.WriteLine(genre);
//            }

//    Console.WriteLine("Ange genre-ID: ");
//            int genreIdInput = int.Parse(Console.ReadLine()!);

//    Console.WriteLine("Ange titel: ");
//            string titelInput = Console.ReadLine()!;

//    Console.WriteLine("Ange utgivningsår: ");
//            int releaseYear = int.Parse(Console.ReadLine()!);


//    var newMovie = new Movie //  Packa ihop användarens svar till ETT Movie-objekt
//    {
//        Title = titelInput,
//        ReleaseYear = releaseYear,
//        GenreId = genreIdInput
//    };

//    // Skicka paketet till databasen
//    int rowsAffected = repo.AddMovie(newMovie);

//            if (rowsAffected == 1)
//            {
//                Console.WriteLine($"{rowsAffected} film lades till.");
//                Console.WriteLine($"Filmen {newMovie} lades till.");
//            }

//foreach (var movie in repo.GetAllMovies())
//{
//    Console.WriteLine(movie);
//}
//    }
//}
