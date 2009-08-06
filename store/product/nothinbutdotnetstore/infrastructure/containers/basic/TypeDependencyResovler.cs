using System;

namespace nothinbutdotnetstore.infrastructure.containers.basic
{
    public interface TypeDependencyResovler
    {
        object resolve_concrete_type(Type type_of_class_to_resolve);
    }
}