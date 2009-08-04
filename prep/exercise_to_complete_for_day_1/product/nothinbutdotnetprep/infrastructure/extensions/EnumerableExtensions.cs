using System;
using System.Collections.Generic;
using nothinbutdotnetprep.infrastructure.sorting;

namespace nothinbutdotnetprep.infrastructure.extensions
{
    static public class EnumerableExtensions
    {
        static public IEnumerable<T> sort_using<T, PropertyType>(this IEnumerable<T> items,
                                                                 Func<T, PropertyType> accessor)
            where PropertyType : IComparable<PropertyType>
        {
            return items.sort_using(new PropertyComparer<T, PropertyType>(accessor));
        }

        static public IEnumerable<T> sort_using<T>(this IEnumerable<T> items,
                                                   IComparer<T> comparer)
        {
            var sorted = new List<T>(items);
            sorted.Sort(comparer);
            return sorted;
        }
    }
}