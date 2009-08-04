using System.Collections.Generic;

namespace nothinbutdotnetprep.infrastructure.sorting
{
    public class SortOrders
    {
        static public readonly SortOrder ascending = new AscendingSortOrder();
        static public readonly SortOrder descending = new DescendingSortOrder();
    }

    public interface SortOrder
    {
        IComparer<T> apply_to<T>(IComparer<T> comparer);
    }

    public class AscendingSortOrder : SortOrder
    {
        public IComparer<T> apply_to<T>(IComparer<T> comparer)
        {
            return comparer;
        }
    }

    public class DescendingSortOrder : SortOrder
    {
        public IComparer<T> apply_to<T>(IComparer<T> comparer)
        {
            return new ReverseComparer<T>(comparer);
        }
    }
}