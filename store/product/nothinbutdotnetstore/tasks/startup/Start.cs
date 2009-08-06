using System.Collections.Generic;
using nothinbutdotnetstore.infrastructure.containers.basic;

namespace nothinbutdotnetstore.tasks.startup
{
    public class Start
    {
        static public ApplicationStartupPipelineBuilder by<StartupCommandType>()
        {
            return new ApplicationStartupPipelineBuilder(
                new ApplicationStartupCommandFactoryImplementation(), new List<ApplicationStartupCommand>(),
                new ContainerResolverRegistryImplementation(new List<ContainerItemResolver>()),typeof(StartupCommandType));
        }
    }
}