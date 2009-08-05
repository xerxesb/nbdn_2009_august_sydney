using developwithpassion.bdd;
using developwithpassion.bdd.contexts;
using developwithpassion.bdd.mbunit;
using developwithpassion.bdd.mbunit.standard.observations;
using developwithpassion.bdddoc.core;
using nothinbutdotnetstore.infrastructure;
using nothinbutdotnetstore.web.core.frontcontroller;
using Rhino.Mocks;

namespace nothinbutdotnetstore.tests.web
{
    public class RequestCommandSpecs
    {
        public abstract class concern : observations_for_a_sut_with_a_contract<RequestCommand,
                                            RequestCommandImplementation> {}

        internal class when_processing_the_request : concern
        {
            context c = () =>
            {
                request = an<IncomingRequest>();
                raw_command = the_dependency<RawRequestCommand>();
            };
            because b = () =>
            {
                sut.process(request);
            };

            it should_use_the_raw_command_to_process_the_request = () =>
            {
                raw_command.received(x => x.process(request));
            };

            static RawRequestCommand raw_command;
            static IncomingRequest request;
        }

        [Concern(typeof (RequestCommandImplementation))]
        public class when_determining_if_it_can_process_a_request : concern
        {
            context c = () =>
            {
                request = an<IncomingRequest>();
                request_specification = the_dependency<Specification<IncomingRequest>>();
                request_specification.Stub(x => x.is_satisfied_by(request)).Return(true);
            };

            because b = () =>
            {
                result = sut.can_handle(request);
            };


            it should_make_the_decision_by_usings_its_request_specification = () =>
            {
                result.should_be_true();
            };

            static bool result;
            static IncomingRequest request;
            static Specification<IncomingRequest> request_specification;
        }
    }
}