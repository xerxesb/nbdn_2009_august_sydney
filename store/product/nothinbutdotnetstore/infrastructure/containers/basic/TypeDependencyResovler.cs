using System;

namespace nothinbutdotnetstore.infrastructure.containers.basic
{
    public interface TypeDependencyResovler
    {
        T resolve_concrete_type<T>();
        object resolve_concrete_type(Type type_of_class_to_resolve);
    }
}