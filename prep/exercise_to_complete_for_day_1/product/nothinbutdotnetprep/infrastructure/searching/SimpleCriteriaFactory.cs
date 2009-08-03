using System;

namespace nothinbutdotnetprep.infrastructure.searching
{
    public class SimpleCriteriaFactory<Item, PropertyType>
    {
        Func<Item, PropertyType> accessor;

        public SimpleCriteriaFactory(Func<Item, PropertyType> accessor)
        {
            this.accessor = accessor;
        }

        public Criteria<Item> equal_to(PropertyType value)
        {
            return new AnonymousCriteria<Item>(item =>
                                               accessor(item).Equals(value));
        }
    }
}