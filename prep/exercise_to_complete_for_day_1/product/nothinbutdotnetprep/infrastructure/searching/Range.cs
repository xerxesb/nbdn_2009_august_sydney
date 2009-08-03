using System;

namespace nothinbutdotnetprep.infrastructure.searching
{
    public interface Range<T> where T : IComparable<T>
    {
        bool contains(T item);
    }
}