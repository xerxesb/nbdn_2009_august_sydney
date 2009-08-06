using System.Collections.Generic;
using System.Linq;

namespace nothinbutdotnetstore.tests.utility
{
    public class ObjectMother
    {
        static public IEnumerable<T> create_enumerable_from<T>(params T[] items)
        {
            return items.Select(item => item);
        }
    }
}