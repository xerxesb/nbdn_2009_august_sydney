using nothinbutdotnetprep.specifications;

namespace nothinbutdotnetprep.infrastructure.extensions
{
    static public class SpecificationExtensions
    {
        static public ISpecification<T> and<T>(this ISpecification<T> left, ISpecification<T> right)
        {
            return new AndSpecification<T>(left, right);
        }

        static public ISpecification<T> or<T>(this ISpecification<T> left, ISpecification<T> right)
        {
            return new OrSpecification<T>(left, right);
        }

        static public ISpecification<T> not<T>(this ISpecification<T> specification_to_negate)
        {
            return new NotSpecification<T>(specification_to_negate);
        }
    }
}