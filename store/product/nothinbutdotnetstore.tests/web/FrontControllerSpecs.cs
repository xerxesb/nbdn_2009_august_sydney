using developwithpassion.bdd;
using developwithpassion.bdd.contexts;
using developwithpassion.bdd.mbunit.standard.observations;
using developwithpassion.bdddoc.core;
using nothinbutdotnetstore.web.frontcontroller;
using Rhino.Mocks;

namespace nothinbutdotnetstore.tests.web
{
    public class FrontControllerSpecs
    {
        public abstract class concern : observations_for_a_sut_with_a_contract<FrontController,
                                            FrontControllerImplementation> {}

        [Concern(typeof (FrontControllerImplementation))]
        public class when_processing_a_request : concern
        {
            context c = () =>
            {
                command = an<RequestCommand>();
                request = an<IncomingRequest>();
                command_registry = the_dependency<CommandRegistry>();
                command_registry.Stub(x => x.get_command_that_can_handle(request)).Return(command);
            };


            because b = () =>
            {
                sut.process(request);
            };


            it should_tell_the_command_that_can_process_the_request_to_process_it = () =>
            {
                command.received(x => x.process(request));
            };

            static RequestCommand command;
            static IncomingRequest request;
            static CommandRegistry command_registry;
        }
    }
}