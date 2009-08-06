using System;
using System.Collections.Generic;

namespace nothinbutdotnetstore.tasks.startup
{
    public class ApplicationStartupPipelineBuilder
    {
        readonly ApplicationStartupCommandConstructor startup_command_constructor;
        readonly List<ApplicationStartupCommand> commands;

        public ApplicationStartupPipelineBuilder(ApplicationStartupCommandConstructor startup_command_constructor, List<ApplicationStartupCommand> commands)
        {
            this.startup_command_constructor = startup_command_constructor;
            this.commands = commands;
        }

        public ApplicationStartupPipelineBuilder followed_by<T>()
        {
            var startup_command = startup_command_constructor.create(typeof (T), null);
            commands.Add(startup_command);
            return this;
        }

        public void finish_by<StartupCommandType>()
        {
            followed_by<StartupCommandType>();
            commands.ForEach(command => command.run());
        }
    }
}