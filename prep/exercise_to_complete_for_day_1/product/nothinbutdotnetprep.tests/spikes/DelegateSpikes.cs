 
using System;
using developwithpassion.bdd.contexts;
using developwithpassion.bdd.mbunit.standard.observations;
using developwithpassion.bdddoc.core;
using nothinbutdotnetprep.collections;

namespace nothinbutdotnetprep.tests.spikes
{
    public class DelegateSpikes
    {
        public abstract class concern : observations_for_a_static_sut {}

        [Concern(typeof (Delegate))]
        public class when_observation_name : concern
        {
            context c = () => {};

            because b = () => {};


            it first_observation = () =>
            {
                var first = new Movie {title = "blah"};
                Action do_something = first.do_something;
                do_something.Method.Invoke(new Movie { title = "Indiana Jones" }, new object[0]);


            };
        }

        public class SomeOther {
            public void do_something() {
                Console.Out.WriteLine("Yeah");
            }
        }
    }
}
