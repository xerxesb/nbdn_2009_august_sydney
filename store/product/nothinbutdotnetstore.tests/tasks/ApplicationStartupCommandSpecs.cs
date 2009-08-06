using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using developwithpassion.bdd.contexts;
using developwithpassion.bdd.mbunit.standard.observations;
using developwithpassion.bdddoc.core;
using nothinbutdotnetstore.infrastructure;
using nothinbutdotnetstore.tasks;
using nothinbutdotnetstore.tasks.startup;
using developwithpassion.bdd.mbunit;

namespace nothinbutdotnetstore.tests.tasks
{
    public class ApplicationStartupCommandSpecs
    {
        public abstract class concern : observations_for_a_static_sut {}

        [Concern(typeof (ApplicationStartupCommand))]
        public class when_a_command_wants_to_be_an_application_startup_command : concern
        {
            context c = () => {};

            because b = () =>
            {
                all_startup_commands = typeof (ApplicationStartupCommand).Assembly.GetTypes()
                    .Where(type => typeof (ApplicationStartupCommand).IsAssignableFrom(type));
            };


            it should_support_the_constructor_that_allows_it_to_be_used_in_the_startup_pipeline = () =>
            {
                all_startup_commands.each(type => type.GetType().only_has_a_constructor_with(typeof (ContainerResolverRegistry)));
            };

            static IEnumerable<Type> all_startup_commands;
        }
    }

    static public class AssertionExtension
    {
        static public ConstructorInfo greediest_constructor(this Type type)
        {
            return type.GetConstructors().OrderByDescending(item => item.GetParameters().Count()).First();
        }

        static public void only_has_a_constructor_with(this Type type,params Type[] types) {
            var constructor_args = type.greediest_constructor().GetParameters();
            var list = new List<Type>(types);

            constructor_args.Count().should_be_equal_to(list.Count);
            foreach (var constructor_argument in list)
            {
                list.should_contain(constructor_argument);    
            }
        }

    }
}