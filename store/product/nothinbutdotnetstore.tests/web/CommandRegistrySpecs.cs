using System.Collections.Generic;
using developwithpassion.bdd.contexts;
using developwithpassion.bdd.mbunit;
using developwithpassion.bdd.mbunit.standard.observations;
using developwithpassion.bdddoc.core;
using nothinbutdotnetstore.web.core.frontcontroller;
using Rhino.Mocks;

namespace nothinbutdotnetstore.tests.web
{
    public class CommandRegistrySpecs
    {
        public abstract class concern : observations_for_a_sut_with_a_contract<CommandRegistry,
                                            CommandRegistryImplementation>
        {
            context c = () =>
            {
                request = an<IncomingRequest>();
                commands = new List<RequestCommand>();
                provide_a_basic_sut_constructor_argument<IEnumerable<RequestCommand>>(commands);
            };

            static protected IList<RequestCommand> commands;
            static protected IncomingRequest request;
        }

        [Concern(typeof (CommandRegistry))]
        public class when_getting_a_command_for_a_request_that_it_has_a_command_for : concern
        {
            context c = () =>
            {
                command_that_can_handle_the_request = an<RequestCommand>();
                command_that_can_handle_the_request.Stub(x => x.can_handle(request)).Return(true);
                commands.Add(command_that_can_handle_the_request);
                commands.Add(an<RequestCommand>());
            };

            because b = () =>
            {
                result = sut.get_command_that_can_handle(request);
            };


            it should_return_the_command_that_can_handle_the_request = () =>
            {
                result.should_be_equal_to(command_that_can_handle_the_request);
            };

            static RequestCommand result;
            static RequestCommand command_that_can_handle_the_request;
        }

        public class when_getting_a_command_and_there_is_no_command_to_process_the_request : concern
        {
            because b = () =>
            {
                result = sut.get_command_that_can_handle(request);
            };

            it should_return_a_missing_command_to_the_caller = () =>
            {
                result.should_be_an_instance_of<MissingRequestCommand>();
            };

            static RequestCommand result;
        }
    }
}