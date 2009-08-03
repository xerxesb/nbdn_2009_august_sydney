using System;

namespace nothinbutdotnetprep.infrastructure.searching
{
    public class RangeCriteria<T> : Criteria<T> where T : IComparable<T>
    {
        Range<T> range;

        public RangeCriteria(Range<T> range)
        {
            this.range = range;
        }

        public bool is_satisfied_by(T item)
        {
            return range.contains(item);
        }
    }
}