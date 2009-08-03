using nothinbutdotnetprep.specifications;

namespace nothinbutdotnetprep.infrastructure
{
    public class AndSpecification<T> : ISpecification<T>
    {
        readonly ISpecification<T> left_side;
        readonly ISpecification<T> right_side;

        public AndSpecification(ISpecification<T> left_side, ISpecification<T> right_side)
        {
            this.left_side = left_side;
            this.right_side = right_side;
        }

        public bool is_satisfied_by(T item)
        {
            return left_side.is_satisfied_by(item) && right_side.is_satisfied_by(item);
        }
    }
}