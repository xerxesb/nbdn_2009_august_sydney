using nothinbutdotnetprep.infrastructure.searching;

namespace nothinbutdotnetprep.collections
{
    public class ProducedByCriteria : Criteria<Movie>
    {
        ProductionStudio production_studio;

        public ProducedByCriteria(ProductionStudio production_studio)
        {
            this.production_studio = production_studio;
        }

        public bool is_satisfied_by(Movie movie)
        {
            return movie.production_studio.Equals(production_studio);
        }
    }
}