using System;
using System.Data;
using System.Data.SqlClient;
using developwithpassion.bdd.contexts;
using developwithpassion.bdd.mbunit;
using developwithpassion.bdd.mbunit.standard.observations;
using developwithpassion.bdddoc.core;
using developwithpassion.commons.core.infrastructure.containers;
using nothinbutdotnetstore.infrastructure.containers.basic;
using Rhino.Mocks;

namespace nothinbutdotnetstore.tests.infrastructure
{
    public class BasicContainerSpecs
    {
        public abstract class concern : observations_for_a_sut_with_a_contract<Container,
                                            BasicContainer> {

        }

        [Concern(typeof (BasicContainer))]
        public class when_getting_an_instance_of_a_component : concern
        {
            context c = () => 
            {
                sql_connection = new SqlConnection();

                type_dependency_resolver = the_dependency<TypeDependencyResolver>();
                type_dependency_resolver.Stub(x => x.resolve_concrete_type(typeof(IDbConnection))).Return(sql_connection);
            };

            because b = () => 
            {
                result = sut.instance_of<IDbConnection>();
            };


            it should_return_the_instance_that_was_resolved_using_the_types_dependency_resolver = () =>
            {
                result.should_be_equal_to(sql_connection);
            };

            static IDbConnection result;
            static SqlConnection sql_connection;
            static TypeDependencyResolver type_dependency_resolver;
        }

        [Concern(typeof (BasicContainer))]
        public class when_getting_an_instance_of_a_component_by_using_its_type : concern
        {
            context c = () => 
            {
                sql_connection = new SqlConnection();

                type_dependency_resolver = the_dependency<TypeDependencyResolver>();
                type_dependency_resolver.Stub(x => x.resolve_concrete_type(typeof(IDbConnection))).Return(sql_connection);
            };

            because b = () => {

                result = sut.instance_of(typeof(IDbConnection));
            };


            it should_return_the_instance_that_was_resolved_using_the_types_dependency_resolver = () =>
            {
                result.should_be_equal_to(sql_connection);
            };

            static object result;
            static SqlConnection sql_connection;
            static TypeDependencyResolver type_dependency_resolver;
        }

        //[Concern(typeof (BasicContainer))]
        //public class when_trying_to_get_an_instance_of_a_type_that_has_no_resolver_registered : concern
        //{
        //    because b = () => 
        //    {
        //        doing(() => sut.instance_of<IDbConnection>());
        //    };


        //    it should_throw_an_resolver_not_registered_exception = () =>
        //    {
        //        exception_thrown_by_the_sut.should_be_an_instance_of<ResolverNotRegisteredException>()
        //            .type_that_could_not_be_resolved.should_be_equal_to(typeof (IDbConnection));
        //    };

        //}

        [Concern(typeof (BasicContainer))]
        public class when_the_dependency_resolver_for_a_type_causes_an_exception_to_be_thrown_while_trying_to_resolve_a_type : concern
        {
            context c = () =>
            {
                inner_exception = new Exception();

                type_dependency_resolver = the_dependency<TypeDependencyResolver>();
                type_dependency_resolver.Stub(x => x.resolve_concrete_type(typeof(IDbConnection))).Throw(inner_exception);
            };

            because b = () => {

                doing(() => sut.instance_of<IDbConnection>());
            };


            it should_throw_an_container_resolver_exception_that_provides_access_to_all_of_the_required_exception_information = () =>
            {
                var exception = exception_thrown_by_the_sut.should_be_an_instance_of<ContainerResolverException>();
                exception.type_that_could_not_be_resolved.should_be_equal_to(typeof(IDbConnection));
                exception.InnerException.should_be_equal_to(inner_exception);
            };

            static Exception inner_exception;
            static TypeDependencyResolver type_dependency_resolver;
        }
    }
}