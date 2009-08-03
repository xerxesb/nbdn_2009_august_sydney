using nothinbutdotnetprep.collections;

namespace nothinbutdotnetprep.specifications
{
    public class MovieLibraryProductionStudioSpecification : ISpecification<Movie>
    {
        ProductionStudio production_studio;

        public MovieLibraryProductionStudioSpecification(ProductionStudio production_studio)
        {
            this.production_studio = production_studio;
        }

        public bool is_satisfied_by(Movie item)
        {
            return item.production_studio.Equals(production_studio);
        }
    }
}