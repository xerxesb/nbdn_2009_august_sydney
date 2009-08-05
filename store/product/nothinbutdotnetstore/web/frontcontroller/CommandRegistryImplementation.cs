using System;
using System.Collections.Generic;
using System.Linq;
using nothinbutdotnetstore.infrastructure;
using nothinbutdotnetstore.web.application.catalogbrowsing;

namespace nothinbutdotnetstore.web.frontcontroller
{
    public class CommandRegistryImplementation : CommandRegistry
    {
        IEnumerable<RequestCommand> commands;
        public CommandRegistryImplementation():this(build_default_command_set()) {}

        static IEnumerable<RequestCommand> build_default_command_set()
        {
            yield return new RequestCommandImplementation(new AnySpecification<IncomingRequest>(),
                                                          new ViewMainDepartments());

        }

        public CommandRegistryImplementation(IEnumerable<RequestCommand> commands)
        {
            this.commands = commands;
        }

        public RequestCommand get_command_that_can_handle(IncomingRequest request)
        {
            return commands.FirstOrDefault(command => command.can_handle(request)) ?? new MissingRequestCommand();
        }

        class AnySpecification<T> : Specification<T>
        {
            public bool is_satisfied_by(T item)
            {
                return true;
            }
        }
    }
}