namespace nothinbutdotnetstore.web.core.frontcontroller
{
    public class FrontControllerImplementation : FrontController
    {
        CommandRegistry command_registry;

        public FrontControllerImplementation(CommandRegistry command_registry)
        {
            this.command_registry = command_registry;
        }

        public void process(IncomingRequest request)
        {
            command_registry.get_command_that_can_handle(request).process(request);
        }
    }
}