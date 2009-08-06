namespace nothinbutdotnetstore.infrastructure.containers.basic
{
    public interface TypeDependencyResovler
    {
        T resolve_concrete_type<T>();
    }
}