using developwithpassion.bdd.contexts;
using developwithpassion.bdd.mbunit;
using developwithpassion.bdd.mbunit.standard.observations;
using developwithpassion.bdddoc.core;
using nothinbutdotnetstore.tasks;
using nothinbutdotnetstore.tasks.startup;

namespace nothinbutdotnetstore.tests.tasks
{
    public class StartSpecs
    {
        public abstract class concern : observations_for_a_static_sut {}

        [Concern(typeof (Start))]
        public class when_starting_pipeline : concern
        {
            static public int number_of_commands_run;

            because b = () =>
            {
                result = Start.by<FakeCommand>();
            };

            after_each_observation a = () =>
            {
                number_of_commands_run = 0;
            };


            it should_return_a_valid_pipeline_builder_that_can_build_chains_of_commands = () =>
            {
                result.should_not_be_null();
                result.followed_by<FakeCommand>()
                      .followed_by<FakeCommand>()
                      .followed_by<FakeCommand>()
                      .finish_by<FakeCommand>();

                number_of_commands_run.should_be_equal_to(5);
            };


            static ApplicationStartupPipelineBuilder result;
        }

        public class FakeCommand : ApplicationStartupCommand
        {
            public FakeCommand(ContainerResolverRegistry registry) {}

            public void run()
            {
                when_starting_pipeline.number_of_commands_run++;
            }
        }
    }
}