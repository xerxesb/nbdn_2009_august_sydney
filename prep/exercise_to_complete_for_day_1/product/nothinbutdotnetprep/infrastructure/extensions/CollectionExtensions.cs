using System.Collections.Generic;

namespace nothinbutdotnetprep.infrastructure.extensions
{
    static public class CollectionExtensions
    {
        static public void add_all<T>(this IList<T> list, params T[] items)
        {
            foreach (var t in items) list.Add(t);
        }
    }
}