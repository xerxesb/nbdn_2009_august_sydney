namespace nothinbutdotnetprep.infrastructure.searching
{
    static public class CriteriaExtensions
    {
        static public Criteria<T> and<T>(this Criteria<T> left, Criteria<T> right)
        {
            return new AndCriteria<T>(left, right);
        }
    }

}