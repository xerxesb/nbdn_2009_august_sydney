 using developwithpassion.bdd.contexts;
 using developwithpassion.bdd.mbunit.standard.observations;
 using developwithpassion.bdddoc.core;
 using nothinbutdotnetstore.tasks.startup;

namespace nothinbutdotnetstore.tests.infrastructure
 {   
     public class StartupCommandBuilderSpecs
     {
         public abstract class concern : observations_for_a_sut_with_a_contract<StartupCommandBuilder,
                                             StartupCommandBuilderImplementation>
         {
        
         }

         [Concern(typeof(StartupCommandBuilderImplementation))]
         public class when_created : concern
         {
             context c = () =>
             {
            
             };

             because b = () =>
             {
        
             };

        
             it should_create_a_command = () =>
             {
                 
            
            
             };
         }
     }
 }
