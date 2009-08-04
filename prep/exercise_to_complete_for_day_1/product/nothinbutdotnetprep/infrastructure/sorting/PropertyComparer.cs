using System;
using System.Collections.Generic;

namespace nothinbutdotnetprep.infrastructure.sorting
{
    public class PropertyComparer<Item, PropertyType> : IComparer<Item> where PropertyType : IComparable<PropertyType>
    {
        readonly Func<Item, PropertyType> accessor;

        public PropertyComparer(Func<Item,PropertyType> accessor) {
            this.accessor = accessor;
        }

        public int Compare(Item x, Item y)
        {
            return accessor(x).CompareTo(accessor(y));
        }
    }
}