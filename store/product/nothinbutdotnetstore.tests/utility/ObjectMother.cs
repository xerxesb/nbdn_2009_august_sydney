using System.Collections.Generic;

namespace nothinbutdotnetstore.tests.utility
{
    public class ObjectMother
    {
        static public IEnumerable<T> create_enumerable_from<T>(params T[] items)
        {
            foreach (var item in items)
            {
                yield return item;
            }
        }
    }
}