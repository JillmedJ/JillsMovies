using JillsMovies.Data;
using JillsMovies.Models;

namespace JillsMovies.UI
{
    internal class MovieMenuCases
    {

        private readonly MovieRepository _repo = new MovieRepository();

        internal void AddMovie()
        {
            // Skriv ut varje genre – använder ToString() i Genre
            foreach (var genre in _repo.GetAllGenres())
            {
                Console.WriteLine(genre);
            }

            Console.WriteLine("Ange genre-ID: ");
            if (!int.TryParse(Console.ReadLine(), out int genreIdInput))
            {
                Console.WriteLine("Du måste ange en siffra.");
                Console.WriteLine();
                return;
            }

            Console.WriteLine("Ange titel: ");
            string titelInput = Console.ReadLine()!;
            Console.WriteLine();

            Console.WriteLine("Ange utgivningsår: ");
            if (!int.TryParse(Console.ReadLine(), out int releaseYearInput))
            {
                Console.WriteLine("Du måste ange ett fyrsiftigt årtal.");
                Console.WriteLine();
                return;
            }


            var newMovie = new Movie //  Packa ihop användarens svar till ETT Movie-objekt
            {
                Title = titelInput,
                ReleaseYear = releaseYearInput,
                GenreId = genreIdInput
            };

            // Skicka paketet till databasen
            int rowsAffected = _repo.AddMovie(newMovie);

            if (rowsAffected == 1)
            {
                Console.WriteLine($"{rowsAffected} film lades till.");
                Console.WriteLine($"Filmen {newMovie} lades till.");
            }

            foreach (var movie in _repo.GetAllMovies())
            {
                Console.WriteLine(movie);
            }
        }

        internal void DeleteMovie()
        {
            // Skriv ut varje genre – använder ToString() i Genre
            foreach (var movie in _repo.GetAllMovies())
            {
                Console.WriteLine($"{movie.Id}. {movie}");
            }

            Console.WriteLine();

            Console.WriteLine("Ange film-ID: ");
            if (!int.TryParse(Console.ReadLine(), out int movieIdInput))
            {
                Console.WriteLine("Du måste ange en siffra.");
                Console.WriteLine();

                return;
            }

            // Skicka paketet till databasen
            int rowsAffected = _repo.DeleteMovie(movieIdInput);

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

            foreach (var movie in _repo.GetAllMovies())
            {
                Console.WriteLine(movie);
                Console.WriteLine();
            }
        }

        internal void ShowAllMovies()
        {
            foreach (var movie in _repo.GetAllMovies())
            {
                Console.WriteLine($"{movie.Id}. {movie}");
                Console.WriteLine();
            }
        }

        internal void SearchByGenre()
        {
            // Visa genrerna med Id
            foreach (var genre in _repo.GetAllGenres())
            {
                Console.WriteLine(genre);
                Console.WriteLine();
            }

            Console.WriteLine("Ange genre-ID: ");
            if (!int.TryParse(Console.ReadLine(), out int genreIdInput))
            {
                Console.WriteLine("Du måste ange en siffra.");
                Console.WriteLine();
                return;
            }

            var movies = _repo.GetMoviesByGenre(genreIdInput);

            if (movies.Count == 0)
            {
                Console.WriteLine("Inga filmer hittades i den genren.");
                Console.WriteLine();
                return;
            }

            foreach (var movie in movies)
            {
                Console.WriteLine(movie);
                Console.WriteLine();
            }


        }
    }
}
