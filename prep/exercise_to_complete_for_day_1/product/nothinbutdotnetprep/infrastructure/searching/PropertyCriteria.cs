using System;

namespace nothinbutdotnetprep.infrastructure.searching
{
    public class PropertyCriteria<Item,PropertyType> : Criteria<Item>
    {
        Func<Item, PropertyType> accessor;
        Criteria<PropertyType> raw_criteria;

        public PropertyCriteria(Func<Item, PropertyType> accessor, Criteria<PropertyType> raw_criteria)
        {
            this.accessor = accessor;
            this.raw_criteria = raw_criteria;
        }

        public bool is_satisfied_by(Item item)
        {
            var property_value = accessor(item);
            return raw_criteria.is_satisfied_by(property_value);
        }
    }
}