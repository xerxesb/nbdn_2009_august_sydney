using System.Collections.Generic;
using developwithpassion.commons.core.infrastructure.containers;
using nothinbutdotnetstore.infrastructure;
using nothinbutdotnetstore.web.application.catalogbrowsing;
using nothinbutdotnetstore.web.core.frontcontroller;

namespace nothinbutdotnetstore.tasks.startup
{
    public class ConfigureTheApplicationRoutes : ApplicationStartupCommand
    {
        ContainerResolverRegistry registry;

        public ConfigureTheApplicationRoutes(ContainerResolverRegistry registry)
        {
            this.registry = registry;
        }

        public void run()
        {
            registry.register_resolver_for<ViewMainDepartments>(() => new ViewMainDepartments(
                                                                          IOC.get().instance_of<DisplayEngine>(),
                                                                          IOC.get().instance_of<CatalogTasks>()));
            registry.register_resolver_for<IEnumerable<RequestCommand>>(
                () => create_commands());
        }

        IEnumerable<RequestCommand> create_commands()
        {
            yield return new RequestCommandImplementation(new AnyRequest(),
                                                          IOC.get().instance_of<ViewMainDepartments>());
        }

        class AnyRequest : Specification<IncomingRequest>
        {
            public bool is_satisfied_by(IncomingRequest item)
            {
                return true;
            }
        }
    }
}