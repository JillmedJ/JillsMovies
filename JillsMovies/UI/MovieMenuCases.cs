using JillsMovies.Data;
using JillsMovies.Models;

namespace JillsMovies.UI
{
    internal class MovieMenuCases
    {

        private readonly MovieRepository _repo = new MovieRepository();

        internal void AddMovie()
        {
            // Hämta genrerna och SPARA dem i en variabel för att kunna visa det valda innan helt tillagd
            var genres = _repo.GetAllGenres();

            // Skriv ut varje genre – använder ToString() i Genre
            foreach (var genre in genres)
            {
                Console.WriteLine(genre);
            }

            // 1. Efterfårga genre-ID
            Console.WriteLine();
            Console.WriteLine("Ange genre-ID: ");
            if (!int.TryParse(Console.ReadLine(), out int genreIdInput))
            {
                Console.WriteLine("Du måste ange en siffra.");
                Console.WriteLine();
                return;
            }

            // 2. Leta upp genren med det Id som användaren valde
            var chosenGenre = genres.FirstOrDefault(g => g.Id == genreIdInput);
            if (chosenGenre == null)
            {
                Console.WriteLine("Det finns ingen genre med det Id:t.");
                return;
            }

            Console.WriteLine($"Du valde genre: {chosenGenre.GenreName}");
            Console.WriteLine();


            // 3. Titel
            Console.WriteLine("Ange titel: ");
            string titelInput = Console.ReadLine() ?? "";
            if (string.IsNullOrWhiteSpace(titelInput))
            {
                Console.WriteLine("Titeln får inte vara tom.");
                return;
            }
            Console.WriteLine($"Titel: {titelInput}");
            Console.WriteLine();


            // 4. År
            Console.WriteLine("Ange utgivningsår: ");
            if (!int.TryParse(Console.ReadLine(), out int releaseYearInput))
            {
                Console.WriteLine("Du måste ange ett fyrsiftigt årtal.");
                return;
            }
            Console.WriteLine($"År: {releaseYearInput}");
            Console.WriteLine();

            // 5. Packa ihop och spara
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
                Console.WriteLine($"Filmen \"{titelInput}\" ({releaseYearInput}) - {chosenGenre.GenreName} lades till.");
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
                Console.WriteLine($"{movie}");
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
            }
        }

        internal void ShowAllMovies()
        {
            foreach (var movie in _repo.GetAllMovies())
            {
                Console.WriteLine($"{movie}");
            }
        }

        internal void SearchByGenre()
        {
            // Visa genrerna med Id
            foreach (var genre in _repo.GetAllGenres())
            {
                Console.WriteLine(genre);
            }


            Console.WriteLine();
            Console.WriteLine("Ange genre-ID: ");
            if (!int.TryParse(Console.ReadLine(), out int genreIdInput))
            {
                Console.WriteLine("Du måste ange en siffra.");
                Console.WriteLine();
                return;
            }

            Console.Clear();

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
            }
        }
    }
}
