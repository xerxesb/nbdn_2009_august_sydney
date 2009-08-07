namespace nothinbutdotnetstore.tasks
{
    public interface CatalogRepositoryAndMapper<RepositoryType, ItemMapperType>
    {
        RepositoryType departments { get; }
        ItemMapperType products { get; }
    }
}