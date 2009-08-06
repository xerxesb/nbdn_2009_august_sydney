using System;
using nothinbutdotnetstore.tasks.startup;

namespace nothinbutdotnetstore.tasks
{
    public interface ApplicationStartupCommandFactory
    {
        ApplicationStartupCommand create(Type command_type, ContainerResolverRegistry container_registry);
    }
}