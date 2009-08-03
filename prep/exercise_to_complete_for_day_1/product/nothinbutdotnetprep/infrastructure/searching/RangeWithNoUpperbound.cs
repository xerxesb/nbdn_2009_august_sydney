using System;

namespace nothinbutdotnetprep.infrastructure.searching
{
    public class RangeWithNoUpperbound<T> : Range<T> where T : IComparable<T>
    {
        T start;

        public RangeWithNoUpperbound(T start)
        {
            this.start = start;
        }

        public bool contains(T item)
        {
            return item.CompareTo(start) >= 0;
        }
    }
}