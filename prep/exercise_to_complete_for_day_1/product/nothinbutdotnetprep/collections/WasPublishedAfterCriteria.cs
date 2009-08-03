using System;
using nothinbutdotnetprep.infrastructure.searching;

namespace nothinbutdotnetprep.collections
{
    public class WasPublishedAfterCriteria : Criteria<Movie>
    {
        DateTime date_time;

        public WasPublishedAfterCriteria(DateTime date_time)
        {
            this.date_time = date_time;
        }

        public bool is_satisfied_by(Movie movie)
        {
            return movie.date_published > date_time;
        }
    }
}