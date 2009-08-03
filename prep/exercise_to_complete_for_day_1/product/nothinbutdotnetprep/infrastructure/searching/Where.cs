using System;

namespace nothinbutdotnetprep.infrastructure.searching
{
    public delegate Value PropertySelector<Item, Value>(Item item);

    public class Where<Item>
    {
        static public SimpleCriteriaFactory<Item, PropertyToTarget> has_a<PropertyToTarget>(Func<Item, PropertyToTarget> property_accessor)
        {
            return new SimpleCriteriaFactory<Item, PropertyToTarget>(property_accessor);
        }

        static public SimpleCriteriaFactory<Item, PropertyToTarget> has_an<PropertyToTarget>(Func<Item, PropertyToTarget> property_accessor) where PropertyToTarget : IComparable<PropertyToTarget>
        {
            return new SimpleCriteriaFactory<Item, PropertyToTarget>(property_accessor);
        }
    }
}