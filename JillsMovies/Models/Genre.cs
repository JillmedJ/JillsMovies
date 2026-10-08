using System;
using System.Collections.Generic;
using System.Text;

namespace JillsMovies.Models
{
    internal class Genre
    {
        public int Id { get; set; }
        public string GenreName { get; set; } = string.Empty;

        public override string ToString()
        {
            return $"{Id}. {GenreName}";
        }
    }
}
