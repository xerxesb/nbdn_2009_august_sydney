using developwithpassion.bdd.contexts;
using developwithpassion.bdd.mbunit;
using developwithpassion.bdd.mbunit.standard.observations;
using developwithpassion.bdddoc.core;
using nothinbutdotnetstore.tasks;
using nothinbutdotnetstore.tasks.startup;

namespace nothinbutdotnetstore.tests.tasks
{
    public class ApplicationStartupCommandFactorySpecs
    {
        public abstract class concern : observations_for_a_sut_with_a_contract<ApplicationStartupCommandFactory,
                                            ApplicationStartupCommandFactoryImplementation> {}

        [Concern(typeof (ApplicationStartupCommandFactoryImplementation))]
        public class when_constructing_a_startup_command : concern
        {
            context c = () =>
            {
                resolver_registry = an<ContainerResolverRegistry>();
            };

            because b = () =>
            {
                command_instance = sut.create(typeof (FakeApplicationStartupCommand), resolver_registry);
            };

            it should_construct_command_with_the_registry = () =>
            {
                ((FakeApplicationStartupCommand) command_instance).resolver_registry.should_be_equal_to(resolver_registry);
            };

            static ApplicationStartupCommand command_instance;
            static ContainerResolverRegistry resolver_registry;
        }
    }
}