using System;

namespace nothinbutdotnetstore.infrastructure.containers.basic
{
    public interface ContainerItemResolver
    {
        object resolve();
        bool is_resolver_for(Type type);
    }
}