namespace nothinbutdotnetprep.infrastructure.searching
{
    public interface CriteriaFactory<Item, PropertyType> {
        Criteria<Item> equal_to(PropertyType value);
        Criteria<Item> equal_to_any(params PropertyType[] values);
    }
}