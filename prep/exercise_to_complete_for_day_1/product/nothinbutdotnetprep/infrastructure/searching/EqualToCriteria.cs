namespace nothinbutdotnetprep.infrastructure.searching
{
    public class EqualToCriteria<T> : Criteria<T>
    {
        T value;

        public EqualToCriteria(T value)
        {
            this.value = value;
        }

        public bool is_satisfied_by(T item)
        {
            return item.Equals(value);
        }
    }
}