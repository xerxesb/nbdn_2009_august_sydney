using nothinbutdotnetstore.tasks.stubs;

namespace nothinbutdotnetstore.tasks.startup
{
    public class ConfigureTheServiceLayer : ApplicationStartupCommand
    {
        ContainerResolverRegistry registry;

        public ConfigureTheServiceLayer(ContainerResolverRegistry registry)
        {
            this.registry = registry;
        }


        public void run()
        {
            registry.register_resolver_for<CatalogTasks>(() => new StubCatalogTasks());
        }
    }
}