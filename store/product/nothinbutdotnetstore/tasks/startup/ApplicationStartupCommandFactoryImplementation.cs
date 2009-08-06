using System;

namespace nothinbutdotnetstore.tasks.startup
{
    public class ApplicationStartupCommandFactoryImplementation : ApplicationStartupCommandFactory
    {
        public ApplicationStartupCommand create(Type command_type, ContainerResolverRegistry container_registry)
        {
            return (ApplicationStartupCommand) Activator.CreateInstance(command_type, container_registry);
        }
    }
}