using System;

namespace nothinbutdotnetprep.infrastructure.searching
{
    public class NegatingCriteriaFactory<Item, PropertyType> : CriteriaFactory<Item, PropertyType>
    {
        Func<Item, PropertyType> accessor;
        SimpleCriteriaFactory<Item, PropertyType> factory;

        public NegatingCriteriaFactory(Func<Item, PropertyType> accessor, SimpleCriteriaFactory<Item, PropertyType> factory)
        {
            this.accessor = accessor;
            this.factory = factory;
        }

        public Criteria<Item> equal_to(PropertyType value)
        {
            return new NotCriteria<Item>(factory.equal_to(value));
        }

        public Criteria<Item> equal_to_any(params PropertyType[] values)
        {
            return new NotCriteria<Item>(factory.equal_to_any(values));
        }
    }
}