using System;

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

        public override bool Equals(object obj)
        {
            return Equals(obj as Movie);
        }

        public override int GetHashCode()
        {
            return title.GetHashCode();
        }

        static public Predicate<Movie> is_published_by(ProductionStudio studio)
        {
            return movie => movie.production_studio.Equals(studio);
        }

        static public Predicate<Movie> is_published_after(DateTime date)
        {
            return movie => movie.date_published > date;
        }

        static public Predicate<Movie> is_published_by_and_after(DateTime date, ProductionStudio studio)
        {
            return movie => is_published_by(studio)(movie) &&
                            is_published_after(date)(movie);
        }
    }
}