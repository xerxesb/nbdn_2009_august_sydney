 using developwithpassion.bdd.contexts;
 using developwithpassion.bdd.mbunit.standard.observations;
 using developwithpassion.bdddoc.core;
 using developwithpassion.commons.core.infrastructure.containers;
 using nothinbutdotnetstore.tasks;
 using nothinbutdotnetstore.web.core.frontcontroller;
 using developwithpassion.bdd.mbunit;

namespace nothinbutdotnetstore.tests.tasks
 {   
     public class ApplicationStartupSpecs
     {
         public abstract class concern : observations_for_a_sut_without_a_contract<ApplicationStartup>
         {
        
         }

         [Concern(typeof(ApplicationStartup))]
         public class when_running_application_startup : concern
         {
             context c = () =>
             {
            
             };

             because b = () =>
             {
                sut.run();
             };

        
             it shouldnt_die_in_screaming_agony = () =>
             {
                 var front_controller = IOC.get().instance_of<FrontController>();
                 front_controller.should_not_be_null();
             };
         }
     }
 }
