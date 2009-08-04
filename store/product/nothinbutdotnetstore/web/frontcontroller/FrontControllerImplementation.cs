using System;

namespace nothinbutdotnetstore.web.frontcontroller
{
    public class FrontControllerImplementation : FrontController
    {
        CommandRegistry commandRegistry;
        public FrontControllerImplementation(CommandRegistry command_registry)
        {
            commandRegistry = command_registry;
        }

        public void process(IncomingRequest request)
        {
            var command = commandRegistry.get_command_that_can_handle(request);
            command.process(request);
        }
    }
}