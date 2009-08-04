using System;
using System.Collections.Generic;

namespace nothinbutdotnetprep.infrastructure.sorting
{
    public class SortComparisonBuilder<Item> : IComparer<Item>
    {
        IComparer<Item> comparer;

        public SortComparisonBuilder(IComparer<Item> comparer)
        {
            this.comparer = comparer;
        }

        public SortComparisonBuilder<Item> then_by<PropertyType>(Func<Item, PropertyType> accessor, SortOrder order)
            where PropertyType : IComparable<PropertyType>
        {
            return then_using(order.apply_to(new PropertyComparer<Item, PropertyType>(accessor)));
        }

        public SortComparisonBuilder<Item> then_by<PropertyType>(Func<Item, PropertyType> accessor)
            where PropertyType : IComparable<PropertyType>
        {
            return then_by(accessor, SortOrders.ascending);
        }

        public SortComparisonBuilder<Item> then_using(IComparer<Item> comparer)
        {
            this.comparer = new ChainedComparer<Item>(this.comparer, comparer);
            return this;
        }

        public int Compare(Item x, Item y)
        {
            return comparer.Compare(x, y);
        }
    }
}