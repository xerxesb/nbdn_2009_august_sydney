using System;
using System.Collections.Generic;

namespace nothinbutdotnetprep.infrastructure.sorting
{
    public class Sort<Item>
    {
        static public SortComparisonBuilder<Item> by<PropertyType>(Func<Item, PropertyType> property) where PropertyType : IComparable<PropertyType>
        {
            return with(new PropertyComparer<Item, PropertyType>(property));
        }

        static public SortComparisonBuilder<Item> by_descending<PropertyType>(Func<Item, PropertyType> property) where PropertyType : IComparable<PropertyType>
        {
            return with(new ReverseComparer<Item>(new PropertyComparer<Item, PropertyType>(property)));
        }

        static public SortComparisonBuilder<Item> with(IComparer<Item> comparer)
        {
            return new SortComparisonBuilder<Item>(comparer);
        }
    }
}