using System;
using System.Collections.Generic;

namespace nothinbutdotnetprep.infrastructure.sorting
{
    public class Sort<Item>
    {
        static public SortComparisonBuilder<Item> by<PropertyType>(Func<Item, PropertyType> property) where PropertyType : IComparable<PropertyType>
        {
            return new SortComparisonBuilder<Item>(new PropertyComparer<Item, PropertyType>(property));
        }

        static public SortComparisonBuilder<Item> by_descending<PropertyType>(Func<Item, PropertyType> property) where PropertyType : IComparable<PropertyType>
        {
            return new SortComparisonBuilder<Item>(new ReverseComparer<Item>(new PropertyComparer<Item, PropertyType>(property)));            
        }

        static public void with(IComparer<Item> comparer)
        {
            throw new NotImplementedException();
        }
    }
}