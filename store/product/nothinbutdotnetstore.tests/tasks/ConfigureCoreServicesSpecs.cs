 using System.Collections.Generic;
 using developwithpassion.bdd.contexts;
 using developwithpassion.bdd.mbunit.standard.observations;
 using developwithpassion.bdddoc.core;
 using developwithpassion.commons.core.infrastructure.containers;
 using nothinbutdotnetstore.infrastructure.containers.basic;
 using nothinbutdotnetstore.tasks.startup;
 using developwithpassion.bdd.mbunit;

namespace nothinbutdotnetstore.tests.tasks
 {   
     public class ConfigureCoreServicesSpecs
     {
         public abstract class concern : observations_for_a_sut_with_a_contract<ApplicationStartupCommand,
                                             ConfigureCoreServices>
         {
        
         }

         [Concern(typeof(ConfigureCoreServices))]
         public class when_told_to_run : concern
         {
             context c = () =>
             {
                 provide_a_basic_sut_constructor_argument(resolvers);
            
             };

             because b = () =>
             {
                 sut.run(); 
             };

        
             it should_register_all_of_its_core_services = () =>
             {
                 IOC.get().should_be_an_instance_of<BasicContainer>();
             };

             static IList<ContainerItemResolver> resolvers;
         }
     }
 }
