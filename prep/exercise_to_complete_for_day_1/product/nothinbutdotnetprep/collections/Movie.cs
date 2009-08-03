using System;
using nothinbutdotnetprep.infrastructure;
using nothinbutdotnetprep.specifications;

namespace nothinbutdotnetprep.collections
{
    public class Movie : IEquatable<Movie>
    {
        public string title { get; set; }
        
        public ProductionStudio production_studio { get; set; }
        
        public Genre genre { get; set; }

        public int rating { get; set; }

        public DateTime date_published { get; set; }

        public bool Equals(Movie other)
        {
            return other == null ? false : other.title == title;
        }

        static public ISpecification<Movie> with(Genre genre)
        {
            return new GenreSpecification(genre);
        }

        static public ISpecification<Movie> produced_by(ProductionStudio studio)
        {
            return new MovieLibraryProductionStudioSpecification(studio);
        }

        static public ISpecification<Movie> made_before(DateTime date_time)
        {
            return new LessThanSpecification(date_time);
        }

        static public ISpecification<Movie> made_after(DateTime date_time)
        {
            return new GreaterThanSpecification(date_time);
        }
    }
}