 using System;
 using System.Data;
 using System.Data.SqlClient;
 using developwithpassion.bdd.contexts;
 using developwithpassion.bdd.mbunit.standard.observations;
 using developwithpassion.bdddoc.core;
 using nothinbutdotnetstore.infrastructure;
 using nothinbutdotnetstore.infrastructure.containers.basic;
 using developwithpassion.bdd.mbunit;

namespace nothinbutdotnetstore.tests.infrastructure
 {   
     public class IsSpecificTypeSpecs
     {
         public abstract class concern : observations_for_a_sut_with_a_contract<Specification<Type>,
                                             IsSpecificType>
         {
        
         }

         [Concern(typeof(IsSpecificType))]
         public class when_deciding_if_it_matches_a_type : concern
         {
             context c = () =>
             {
                provide_a_basic_sut_constructor_argument(typeof(IDbConnection));            
             };


        
             it should_match_the_type_if_the_type_is_the_actual_type = () =>
             {
                 sut.is_satisfied_by(typeof (IDbConnection)).should_be_true();
                 sut.is_satisfied_by(typeof (SqlConnection)).should_be_false();
             };
         }
     }
 }
