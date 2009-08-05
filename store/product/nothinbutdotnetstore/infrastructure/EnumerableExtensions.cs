using System;
using System.Collections.Generic;

namespace nothinbutdotnetstore.infrastructure
{
    static public class EnumerableExtensions
    {
        static public void each<Item>(this IEnumerable<Item> items, Action<Item> visitor)
        {
            foreach (var item in items) visitor(item);
        }
    }
}