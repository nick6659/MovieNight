using System;
using System.Collections.Generic;
using System.Text;

namespace MovieNight
{
    class MovieLibrary
    {
        public static List<Movie> MovieList(string search)
        {
            return Dal.GetMovies(search);
        }

        public static List<Movie> GenreMovieList(string search)
        {
            return Dal.GetMoviesByGenre(search);
        }
   
    }
}
