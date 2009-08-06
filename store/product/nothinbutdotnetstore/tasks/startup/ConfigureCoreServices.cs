using developwithpassion.commons.core.infrastructure.containers;
using nothinbutdotnetstore.infrastructure.containers.basic;

namespace nothinbutdotnetstore.tasks.startup
{
    public class ConfigureCoreServices : ApplicationStartupCommand
    {
        ContainerResolverRegistry registry;

        public ConfigureCoreServices(ContainerResolverRegistry registry)
        {
            this.registry = registry;
        }

        public void run()
        {
            IOC.initialize_with(new BasicContainer(registry));
        }
    }
}