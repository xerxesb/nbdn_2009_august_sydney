using System.Collections.Generic;
using nothinbutdotnetprep.collections;

namespace nothinbutdotnetprep.sorting
{
    public interface ISorter
    {
        IEnumerable<Movie> Sort(IList<Movie> list_of_movies, SortOrder order);
    }
}