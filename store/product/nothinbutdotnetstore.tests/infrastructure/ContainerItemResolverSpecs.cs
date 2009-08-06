using System;
using System.Data;
using System.Data.SqlClient;
using developwithpassion.bdd.contexts;
using developwithpassion.bdd.mbunit;
using developwithpassion.bdd.mbunit.standard.observations;
using developwithpassion.bdddoc.core;
using nothinbutdotnetstore.infrastructure.containers.basic;

namespace nothinbutdotnetstore.tests.infrastructure
{
    public class ContainerItemResolverSpecs
    {
        public abstract class concern : observations_for_a_sut_with_a_contract<ContainerItemResolver,
                                            ContainerItemResolverImplementation> {}

        [Concern(typeof (ContainerItemResolverImplementation))]
        public class when_asked_if_it_is_the_resolver_for_a_type : concern
        {
            context c = () =>
            {
                spec = x => true;
                provide_a_basic_sut_constructor_argument(spec);
            };

            because b = () =>
            {
                result = sut.is_resolver_for(typeof (IDbConnection));
            };


            it should_delegate_to_its_specification_to_make_the_decision = () =>
            {
                result.should_be_true();
            };

            static bool result;
            static Func<Type, bool> spec;
        }

        [Concern(typeof (ContainerItemResolverImplementation))]
        public class when_told_to_resolve_a_type : concern
        {
            context c = () =>
            {
                sql_connection = new SqlConnection();
                factory = () => sql_connection;
                provide_a_basic_sut_constructor_argument(factory);
            };

            because b = () =>
            {
                result = sut.resolve();
            };


            it should_delegate_to_its_factory = () =>
            {
                result.should_be_equal_to(sql_connection);
            };

            static object result;
            static SqlConnection sql_connection;
            static Func<object> factory;
        }
    }
}