using System;
using System.Collections.Generic;
using developwithpassion.commons.core.infrastructure.containers;
using nothinbutdotnetstore.infrastructure;
using nothinbutdotnetstore.infrastructure.containers.basic;
using nothinbutdotnetstore.tasks.stubs;
using nothinbutdotnetstore.web.application.catalogbrowsing;
using nothinbutdotnetstore.web.core.frontcontroller;
using nothinbutdotnetstore.web.core.frontcontroller.stubs;

namespace nothinbutdotnetstore.tasks
{
    public class ApplicationStartup
    {
        IList<ContainerItemResolver> resolvers;

        public void run()
        {
            //            Start.with<InitializeTheCore>()
            //                 .then<InitializeTheFrontController>()
            //                 .finish_by<InitializeTheServiceLayer>();

            // Start.by_running_the_pipeline_in("commands.txt")

            // "AutoWireContainerComponents"
            // "ConfigureApplicationRoutes"

            resolvers = new List<ContainerItemResolver>();

            //core
            RawHandler.request_factory = (context => new StubIncomingRequest());

            //Front Controller
            add_resolver_for<FrontController>(() => new FrontControllerImplementation(IOC.get().instance_of<CommandRegistry>()));
            add_resolver_for<CommandRegistry>(() => new CommandRegistryImplementation(IOC.get().instance_of<IEnumerable<RequestCommand>>()));
            add_resolver_for<IEnumerable<RequestCommand>>(() => new RequestCommand[]
                {
                    new RequestCommandImplementation(new AnyRequest(), IOC.get().instance_of<ViewMainDepartments>())
                });

            add_resolver_for<ViewMainDepartments>(() => new ViewMainDepartments(IOC.get().instance_of<DisplayEngine>(), IOC.get().instance_of<CatalogTasks>()));

            add_resolver_for<DisplayEngine>(
                () => new DisplayEngineImplementation(IOC.get().instance_of<ItemRendererRegistry>()));
            add_resolver_for<ItemRendererRegistry>( () => new ItemRendererRegistryImplementation());
            add_resolver_for<WebFormViewRegistry>( () => new StubWebFormViewRegistry());
                
            //service
            add_resolver_for<CatalogTasks>(() => new StubCatalogTasks());

            //Finish
            IOC.initialize_with(new BasicContainer(resolvers));

        }

        void add_resolver_for<T>(Func<object> factory)
        {
            resolvers.Add(new ContainerItemResolverImplementation(factory, type => type.Equals(typeof (T))));
        }

        public class ItemRendererRegistryImplementation : ItemRendererRegistry
        {
            public ItemRender get_renderer_for<Item>()
            {
                return new WebFormRender(IOC.get().instance_of<WebFormViewRegistry>());
            }
        }

        class AnyRequest : Specification<IncomingRequest>
        {
            public bool is_satisfied_by(IncomingRequest item) { return true; }
        }
    }
}