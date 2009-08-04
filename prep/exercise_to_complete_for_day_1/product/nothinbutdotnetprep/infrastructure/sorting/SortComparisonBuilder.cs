using System;
using System.Collections.Generic;

namespace nothinbutdotnetprep.infrastructure.sorting
{
    public class SortComparisonBuilder<Item> : IComparer<Item>
    {
        readonly IComparer<Item> comparer;

        public SortComparisonBuilder(IComparer<Item> comparer)
        {
            this.comparer = comparer;
        }

        public int Compare(Item x, Item y)
        {
            return comparer.Compare(x, y);
        }
    }
}