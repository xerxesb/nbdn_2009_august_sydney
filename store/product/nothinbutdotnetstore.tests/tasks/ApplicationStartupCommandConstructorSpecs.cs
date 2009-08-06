 using System;
 using developwithpassion.bdd.contexts;
 using developwithpassion.bdd.mbunit.standard.observations;
 using developwithpassion.bdddoc.core;
 using nothinbutdotnetstore.tasks;
 using nothinbutdotnetstore.tasks.startup;
 using developwithpassion.bdd.mbunit;

namespace nothinbutdotnetstore.tests.tasks
 {   
     public class ApplicationStartupCommandConstructorSpecs
     {
         public abstract class concern : observations_for_a_sut_with_a_contract<ApplicationStartupCommandConstructor,
                                             ApplicationStartupCommandConstructorImplementation>
         {
        
         }

         [Concern(typeof(ApplicationStartupCommandConstructorImplementation))]
         public class when_constructing_a_startup_command : concern
         {

             context c = () =>
             {
                 resolver_registry = an<ContainerResolverRegistry>();

             };

             because b = () =>
             {
                 command_instance = (FakeApplicationStartupCommand) sut.create(typeof (FakeApplicationStartupCommand), resolver_registry);
             };
        
             it should_construct_command_with_the_registry = () =>
             {
                 command_instance.resolver_registry.should_be_equal_to(resolver_registry);
             };

             static FakeApplicationStartupCommand command_instance;
             static ContainerResolverRegistry resolver_registry;

             class FakeApplicationStartupCommand : ApplicationStartupCommand {
                 public ContainerResolverRegistry resolver_registry { get; private set;}
                 public FakeApplicationStartupCommand(ContainerResolverRegistry resolver_registry)
                 {
                     this.resolver_registry = resolver_registry;
                 }

                 public void run()
                 {
                 }
             }

         }
     }
 }
