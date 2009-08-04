using System;
using System.Collections;
using System.Collections.Generic;
using nothinbutdotnetprep.infrastructure.extensions;

namespace nothinbutdotnetprep.infrastructure.sorting
{
    public class SortedEnumeratorBuilder<Item> : IEnumerable<Item>
    {
        IComparer<Item> _comparer;
        IEnumerable<Item> _enumerable;

        public SortedEnumeratorBuilder(IEnumerable<Item> enumerable, IComparer<Item> comparer)
        {
            _enumerable = enumerable;
            _comparer = comparer;
        }

        public SortedEnumeratorBuilder<Item> then_by<PropertyType>(Func<Item, PropertyType> accessor)
            where PropertyType : IComparable<PropertyType>
        {
            return then_using(new PropertyComparer<Item, PropertyType>(accessor));
        }

        public SortedEnumeratorBuilder<Item> then_by_descending<PropertyType>(Func<Item, PropertyType> accessor)
            where PropertyType : IComparable<PropertyType>
        {
            return then_using(new ReverseComparer<Item>(new PropertyComparer<Item, PropertyType>(accessor)));
        }

        public SortedEnumeratorBuilder<Item> then_using(IComparer<Item> comparer)
        {
            this._comparer = new ChainedComparer<Item>(this._comparer, comparer);
            return this;
        }

        public int Compare(Item x, Item y)
        {
            return _comparer.Compare(x, y);
        }

        public IEnumerator<Item> GetEnumerator()
        {
            return _enumerable.sort_using(_comparer).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public SortedEnumeratorBuilder<Item> then_with(IComparer<Item> comparer)
        {
            return then_using(comparer);
        }
    }
}