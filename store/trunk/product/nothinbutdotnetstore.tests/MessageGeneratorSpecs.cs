using System;
using developwithpassion.bdd.contexts;
using developwithpassion.bdd.mbunit;
using developwithpassion.bdd.mbunit.standard.observations;
using developwithpassion.bdddoc.core;

namespace nothinbutdotnetstore.tests
{
    public class MessageGeneratorSpecs
    {
        public abstract class concern : observations_for_a_sut_without_a_contract<MessageGenerator> {}

        [Concern(typeof (MessageGenerator))]
        public class when_a_message_is_sent : concern
        {
            static string result;

            because b = () =>
            {
                result = sut.say_back_message("blah");
            };

            it should_send_back_the_message_it_was_told = () =>
            {
                result.should_be_equal_to("blah");
            };

            it should_do_some_test = () =>
                                         {
                                             char[] items = new char[1];
                                             items[0] = Convert.ToChar("b");
                                             result.should_contain(items);
                                         };
        }
    }
}
