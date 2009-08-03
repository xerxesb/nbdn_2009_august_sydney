using System;
using System.Collections.Generic;
using nothinbutdotnetprep.sorting;
using nothinbutdotnetprep.specifications;

namespace nothinbutdotnetprep.collections
{
    public class MovieLibrary
    {
        readonly IList<Movie> list_of_movies;

        public MovieLibrary(IList<Movie> list_of_movies)
        {
            this.list_of_movies = list_of_movies;
        }

        public IEnumerable<Movie> all_movies()
        {
            return list_of_movies;
        }

        public void add(Movie movie)
        {
            if (list_of_movies.Contains(movie)) return;

            list_of_movies.Add(movie);
        }

        public IEnumerable<Movie> all_movies_matching(ISpecification<Movie> match)
        {
            foreach (var movie in list_of_movies)
            {
                if (match.is_satisfied_by(movie)) yield return movie;
            }
        }

        public IEnumerable<Movie> sort_by(ISorter sorter, SortOrder sort_order)
        {
            return sorter.Sort(list_of_movies, sort_order);
        }

        public IEnumerable<Movie> sort_all_movies_by_movie_studio_and_year_published()
        {
            throw new NotImplementedException();
        }
    }
}