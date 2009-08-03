namespace nothinbutdotnetprep.infrastructure.searching
{
    public class NotCriteria<T> : Criteria<T>
    {
        Criteria<T> criteria;

        public NotCriteria(Criteria<T> criteria)
        {
            this.criteria = criteria;
        }

        public bool is_satisfied_by(T item)
        {
            return ! criteria.is_satisfied_by(item);
        }
    }
}