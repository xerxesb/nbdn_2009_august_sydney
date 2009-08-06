using System;
using System.Collections.Generic;
using nothinbutdotnetstore.infrastructure;

namespace nothinbutdotnetstore.tasks.startup
{
    public class ApplicationStartupPipelineBuilder
    {
        ApplicationStartupCommandFactory startup_command_factory;
        IList<ApplicationStartupCommand> commands;
        ContainerResolverRegistry registry;

        public ApplicationStartupPipelineBuilder(ApplicationStartupCommandFactory startup_command_factory,
                                                 IList<ApplicationStartupCommand> commands, ContainerResolverRegistry registry,
                                                 Type initial_command_type)
        {
            this.startup_command_factory = startup_command_factory;
            this.registry = registry;
            this.commands = commands;
            add_command(initial_command_type);
        }

        public ApplicationStartupPipelineBuilder followed_by<T>() where T : ApplicationStartupCommand
        {
            add_command(typeof (T));
            return this;
        }

        void add_command(Type command_type)
        {
            var startup_command = startup_command_factory.create(command_type, registry);
            commands.Add(startup_command);
        }

        public void finish_by<StartupCommand>() where StartupCommand : ApplicationStartupCommand
        {
            followed_by<StartupCommand>();
            commands.each(command => command.run());
        }
    }
}