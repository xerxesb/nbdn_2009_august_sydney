using System.Collections.Generic;
using System.Linq;

namespace nothinbutdotnetstore.web.core.frontcontroller
{
    public class CommandRegistryImplementation : CommandRegistry
    {
        IEnumerable<RequestCommand> commands;

        public CommandRegistryImplementation(IEnumerable<RequestCommand> commands)
        {
            this.commands = commands;
        }

        public RequestCommand get_command_that_can_handle(IncomingRequest request)
        {
            return commands.FirstOrDefault(command => command.can_handle(request)) ?? new MissingRequestCommand();
        }
    }
}