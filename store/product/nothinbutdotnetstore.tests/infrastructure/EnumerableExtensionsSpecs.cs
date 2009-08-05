using System;
using System.Collections.Generic;
using System.Linq;
using developwithpassion.bdd.contexts;
using developwithpassion.bdd.mbunit;
using developwithpassion.bdd.mbunit.standard.observations;
using developwithpassion.bdddoc.core;
using nothinbutdotnetstore.infrastructure;

namespace nothinbutdotnetstore.tests.infrastructure
{
    public class EnumerableExtensionsSpecs
    {
        public abstract class concern : observations_for_a_static_sut {}

        [Concern(typeof (EnumerableExtensions))]
        public class when_running_an_action_against_each_item : concern
        {
            context c = () =>
            {
                the_action = item => number_of_items_the_action_ran_against++;
                items = Enumerable.Repeat(new object(), 100);
            };


            because b = () =>
            {
                items.each(the_action);
            };


            it should_run_the_action_against_each_item_in_the_enumerable = () =>
            {
                number_of_items_the_action_ran_against.should_be_equal_to(items.Count());
            };

            static int number_of_items_the_action_ran_against;
            static IEnumerable<object> items;
            static Action<object> the_action;
        }
    }
}