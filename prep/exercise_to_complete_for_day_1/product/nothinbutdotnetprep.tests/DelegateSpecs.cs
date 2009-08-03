 
using System;
using developwithpassion.bdd.contexts;
using developwithpassion.bdd.mbunit.standard.observations;
using developwithpassion.bdddoc.core;

namespace nothinbutdotnetprep.tests
{
    public class DelegateSpecs
    {
        public delegate void MessageGenerator(string message);

        public abstract class concern : observations_for_a_static_sut {}

        [Concern(typeof (Delegate))]
        public class when_messing_around_with_delegates : concern
        {

            it should_not_invoke_until_it_is_called_with_an_instance = () =>
            {
                MessageGenerator output = item => Console.Out.WriteLine(item);
                output += new SomeGenerator().say_something;
                output += item => Console.Out.WriteLine("Lets do something else {0}", item);
                say_hello_using(output,"Blah");
            };

            static void say_hello_using(MessageGenerator generator,string message)
            {
                generator(message);
            }
        }

        public class SomeGenerator {
            public void say_something(string message){
                Console.Out.WriteLine("I am saying {0}",message);
            }
        }
    }
}
