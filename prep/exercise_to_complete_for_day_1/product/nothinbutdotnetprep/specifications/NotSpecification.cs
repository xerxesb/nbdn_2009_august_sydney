using nothinbutdotnetprep.specifications;

namespace nothinbutdotnetprep.infrastructure
{
    public class NotSpecification<T> : ISpecification<T>
    {
        ISpecification<T> specificationToNegate;

        public NotSpecification(ISpecification<T> specification_to_negate)
        {
            specificationToNegate = specification_to_negate;
        }

        public bool is_satisfied_by(T item)
        {
            return !specificationToNegate.is_satisfied_by(item);
        }
    }
}