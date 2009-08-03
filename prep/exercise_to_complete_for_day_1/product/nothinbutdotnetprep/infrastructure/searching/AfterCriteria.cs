using System;

namespace nothinbutdotnetprep.infrastructure.searching
{
    public class AfterCriteria<T> : Criteria<T> where T: IComparable<T>
    {
        T start;

        public AfterCriteria(T start)
        {
            this.start = start;
        }

        public bool is_satisfied_by(T item)
        {
            return item.CompareTo(start) > 0;
        }
    }
}