using System.Collections.Generic;
using nothinbutdotnetprep.collections;

namespace nothinbutdotnetprep.sorting
{
    public class DatePublishedSorter : ISorter
    {
        public IEnumerable<Movie> Sort(IList<Movie> list_of_movies, SortOrder order)
        {
            var list_to_sort = new List<Movie>(list_of_movies);

            list_to_sort.Sort(delegate(Movie left_movie, Movie right_movie)
            {
                if (order == SortOrder.Ascending)
                {
                    return left_movie.date_published.CompareTo(right_movie.date_published);
                }

                return right_movie.date_published.CompareTo(left_movie.date_published);
            });

            return list_to_sort;
        }
    }
}