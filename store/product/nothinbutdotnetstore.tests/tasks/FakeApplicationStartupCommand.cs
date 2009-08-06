using nothinbutdotnetstore.tasks;
using nothinbutdotnetstore.tasks.startup;

namespace nothinbutdotnetstore.tests.tasks
{
    public class FakeApplicationStartupCommand : ApplicationStartupCommand {
        public ContainerResolverRegistry resolver_registry { get; private set;}
        public FakeApplicationStartupCommand(ContainerResolverRegistry resolver_registry)
        {
            this.resolver_registry = resolver_registry;
        }

        public void run()
        {
        }
    }
}