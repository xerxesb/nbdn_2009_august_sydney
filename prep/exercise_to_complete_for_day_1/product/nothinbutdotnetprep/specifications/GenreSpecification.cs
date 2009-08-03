using nothinbutdotnetprep.collections;
using nothinbutdotnetprep.specifications;

namespace nothinbutdotnetprep.infrastructure
{
    public class GenreSpecification : ISpecification<Movie>
    {
        Genre genre;

        public GenreSpecification(Genre genre)
        {
            this.genre = genre;
        }

        public bool is_satisfied_by(Movie item)
        {
            return item.genre.Equals(genre);
        }
    }
}