 
using developwithpassion.bdd.contexts;
using developwithpassion.bdd.mbunit.standard.observations;
using developwithpassion.bdddoc.core;
using nothinbutdotnetstore.tasks.startup;
using developwithpassion.bdd.mbunit;

namespace nothinbutdotnetstore.tests.tasks
{
    public class StartSpecs
    {
        public abstract class concern : observations_for_a_static_sut {}

        [Concern(typeof (Start))]
        public class when_starting_pipeline : concern
        {
            context c = () =>
            {

            };

            because b = () =>
            {
                result = Start.by<ApplicationStartupCommand>();
            };


            it should_return_a_new_pipeline_builder = () =>
            {
                result.should_not_be_null();
            };

            static ApplicationStartupPipelineBuilder result;
        }
    }
}
