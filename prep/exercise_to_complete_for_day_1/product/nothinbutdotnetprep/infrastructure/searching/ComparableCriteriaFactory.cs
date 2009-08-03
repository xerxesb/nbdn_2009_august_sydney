using System;
using nothinbutdotnetprep.collections;

namespace nothinbutdotnetprep.infrastructure.searching
{
    public class ComparableCriteriaFactory<Item, PropertyType> : CriteriaFactory<Item, PropertyType>
        where PropertyType : IComparable<PropertyType>
    {
        Func<Item, PropertyType> accessor;

        public ComparableCriteriaFactory(Func<Item, PropertyType> accessor)
        {
            this.accessor = accessor;
        }

        public Criteria<Item> is_between(PropertyType start, PropertyType end)
        {
            return new PropertyCriteria<Item, PropertyType>(accessor,
                                                            new RangeCriteria<PropertyType>(new InclusiveRange<PropertyType>(
                                                                                                start, end)));
        }

        public Criteria<Item> after(PropertyType value)
        {
            return new PropertyCriteria<Item, PropertyType>(accessor, new AfterCriteria<PropertyType>(value));
        }

        public Criteria<Item> equal_to(PropertyType value)
        {
            throw new NotImplementedException();
        }

        public Criteria<Item> equal_to_any(params PropertyType[] values)
        {
            throw new NotImplementedException();
        }
    }
}