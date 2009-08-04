using System;
using System.Collections.Generic;
using System.Linq;
using nothinbutdotnetprep.infrastructure.searching;
using nothinbutdotnetprep.infrastructure.sorting;

namespace nothinbutdotnetprep.infrastructure.extensions
{
    public static class Iteration
    {
        public static IEnumerable<T> one_at_a_time<T>(this IEnumerable<T> items)
        {
            return items.Select(item => item);
        }

        public static void each<T>(this IEnumerable<T> items, Action<T> action)
        {
            foreach (var item in items) action(item);
        }

        public static IEnumerable<int> to(this int start, int end)
        {
            for (var i = start; i <= end; i++) yield return i;
        }

        public static IEnumerable<T> matching<T>(this IEnumerable<T> items, Criteria<T> criteria)
        {
            foreach (var item in items)
            {
                if (criteria.is_satisfied_by(item)) yield return item;
            }
        }

        public static IEnumerable<T> sort<T>(this IEnumerable<T> items, IComparer<T> comparer)
        {
            var items_to_sort = new List<T>(items);
            items_to_sort.Sort(comparer);
            foreach (var item in items_to_sort)
            {
                yield return item;
            }
        }

        public static EnumerableSortComparisonBuilder<Item> sort_by<Item, PropertyItem>(this IEnumerable<Item> items, Func<Item,PropertyItem> property_accessor)
            where PropertyItem : IComparable<PropertyItem>
        {
            return new EnumerableSortComparisonBuilder<Item>(items, Sort<Item>.by(property_accessor));
        }

        public static EnumerableSortComparisonBuilder<Item> by_descending<Item, PropertyItem>(this IEnumerable<Item> items, Func<Item, PropertyItem> property_accessor)
        where PropertyItem : IComparable<PropertyItem>
        {
            return new EnumerableSortComparisonBuilder<Item>(items, Sort<Item>.by_descending(property_accessor));
        }
    }
}