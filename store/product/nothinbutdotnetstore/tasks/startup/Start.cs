using System;
using System.Collections.Generic;

namespace nothinbutdotnetstore.tasks.startup
{
    public class Start
    {
        public static ApplicationStartupPipelineBuilder by<StartupCommandType>()
        {
            return new ApplicationStartupPipelineBuilder(
                new ApplicationStartupCommandConstructorImplementation(), new List<ApplicationStartupCommand>());
        }
    }
}