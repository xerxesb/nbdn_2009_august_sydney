using System;

namespace nothinbutdotnetprep.infrastructure.searching
{
    public class SimpleCriteriaFactory<Item, PropertyType> : CriteriaFactory<Item, PropertyType>
    {
        Func<Item, PropertyType> accessor;

        public SimpleCriteriaFactory(Func<Item, PropertyType> accessor)
        {
            this.accessor = accessor;
        }

        public CriteriaFactory<Item, PropertyType> not
        {
            get { return new NegatingCriteriaFactory<Item, PropertyType>(accessor, this); }
        }

        public Criteria<Item> equal_to(PropertyType value)
        {
            return new PropertyCriteria<Item, PropertyType>(accessor,
                                                            new EqualToCriteria<PropertyType>(value));
        }

        public Criteria<Item> equal_to_any(params PropertyType[] values)
        {
            return create_criteria(item => Array.IndexOf(values, accessor(item)) > -1);
        }

        Criteria<Item> create_criteria(Predicate<Item> predicate)
        {
            return new AnonymousCriteria<Item>(predicate);
        }

        public Criteria<Item> after(PropertyType value)
        {
            throw new NotImplementedException();
        }
    }
}