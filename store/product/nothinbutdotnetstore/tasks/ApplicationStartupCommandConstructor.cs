using System;
using nothinbutdotnetstore.tasks.startup;

namespace nothinbutdotnetstore.tasks
{
    public interface ApplicationStartupCommandConstructor
    {
        ApplicationStartupCommand create(Type command_type, ContainerResolverRegistry container_registry);
    }
}