using System.Collections.Generic;
using developwithpassion.commons.core.infrastructure.containers;
using nothinbutdotnetstore.web.core.frontcontroller;
using nothinbutdotnetstore.web.core.frontcontroller.stubs;

namespace nothinbutdotnetstore.tasks.startup
{
    public class ConfigureFrontController : ApplicationStartupCommand
    {
        ContainerResolverRegistry registry;

        public ConfigureFrontController(ContainerResolverRegistry registry)
        {
            this.registry = registry;
        }

        public void run()
        {
            RawHandler.request_factory = context => new StubIncomingRequest();
            registry.register_resolver_for<FrontController>(
                () => new FrontControllerImplementation(IOC.get().instance_of<CommandRegistry>()));
            registry.register_resolver_for<CommandRegistry>(
                () => new CommandRegistryImplementation(IOC.get().instance_of<IEnumerable<RequestCommand>>()));

            registry.register_resolver_for<DisplayEngine>(
                () => new DisplayEngineImplementation(IOC.get().instance_of<ItemRendererRegistry>()));
            registry.register_resolver_for<ItemRendererRegistry>(() => new ItemRendererRegistryImplementation());
            registry.register_resolver_for<WebFormViewRegistry>(() => new StubWebFormViewRegistry());
        }
    }

    public class ItemRendererRegistryImplementation : ItemRendererRegistry
    {
        public ItemRender get_renderer_for<Item>()
        {
            return new WebFormRender(IOC.get().instance_of<WebFormViewRegistry>());
        }
    }
}