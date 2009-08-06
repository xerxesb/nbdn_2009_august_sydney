 using developwithpassion.bdd.contexts;
 using developwithpassion.bdd.mbunit.standard.observations;
 using developwithpassion.bdddoc.core;
 using nothinbutdotnetstore.tasks;

namespace nothinbutdotnetstore.tests.tasks
 {   
     public class ContainerResolverRegistySpecs
     {
         public abstract class concern : observations_for_a_sut_with_a_contract<ContainerResolverRegistry,
                                             ContainerResolverRegistryImplementation>
         {
        
         }

         [Concern(typeof(ContainerResolverRegistryImplementation))]
         public class when_a_resolver : concern
         {
             context c = () =>
             {
            
             };

             because b = () =>
             {
        
             };

        
             it first_observation = () =>
             {
                 
            
            
             };
         }
     }
 }
