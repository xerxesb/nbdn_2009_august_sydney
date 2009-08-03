using System;

namespace nothinbutdotnetprep.infrastructure.searching
{
    public class Where<Item>
    {
        static public SimpleCriteriaFactory<Item, PropertyType> has_a<PropertyType>(Func<Item, PropertyType> property_accessor)
        {
            return new SimpleCriteriaFactory<Item, PropertyType>(property_accessor);
        }

        static public ComparableCriteriaFactory<Item, PropertyToTarget> has_an<PropertyToTarget>(Func<Item, PropertyToTarget> property_accessor) where PropertyToTarget : IComparable<PropertyToTarget>
        {
            return new ComparableCriteriaFactory<Item, PropertyToTarget>(property_accessor);
        }
    }
}