using System;
using System.Collections.Generic;

namespace nothinbutdotnetprep.infrastructure.sorting
{
    public class Sort<Item>
    {
        static public void by<PropertyType>(Func<Item, PropertyType> property)
        {
            throw new NotImplementedException();
        }

        static public void by_descending<PropertyType>(Func<Item, PropertyType> property)
        {
            throw new NotImplementedException();
        }

        static public void with(IComparer<Item> comparer)
        {
            throw new NotImplementedException();
        }
    }
}