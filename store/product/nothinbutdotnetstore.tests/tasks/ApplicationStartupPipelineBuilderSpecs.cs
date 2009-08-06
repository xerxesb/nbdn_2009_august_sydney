using System.Collections.Generic;
 using developwithpassion.bdd;
 using developwithpassion.bdd.contexts;
 using developwithpassion.bdd.mbunit.standard.observations;
 using developwithpassion.bdddoc.core;
 using nothinbutdotnetstore.tasks;
 using nothinbutdotnetstore.tasks.startup;
 using Rhino.Mocks;
 using developwithpassion.bdd.mbunit;
 using developwithpassion.bdd.core.extensions;

namespace nothinbutdotnetstore.tests.tasks
 {   
     public class ApplicationStartupPipelineBuilderSpecs
     {
         public abstract class concern : observations_for_a_sut_without_a_contract<ApplicationStartupPipelineBuilder>
         {
             context c = () =>
             {
                 commands = new List<ApplicationStartupCommand>();
                 command_factory = the_dependency<ApplicationStartupCommandFactory>();
                 registry = the_dependency<ContainerResolverRegistry>();

                 provide_a_basic_sut_constructor_argument(commands);
                 provide_a_basic_sut_constructor_argument(typeof(FakeApplicationStartupCommand));
             };


             protected static ApplicationStartupCommandFactory command_factory;
             protected static IList<ApplicationStartupCommand> commands;
             static protected ContainerResolverRegistry registry;
         }

         [Concern(typeof(ApplicationStartupPipelineBuilder))]
         public class kwhen_created_with_an_initial_command_type : concern
         {
             context c = () =>
             {
                 startup_command = an<ApplicationStartupCommand>();
                 command_factory.Stub(x => x.create(typeof (FakeApplicationStartupCommand), registry)).Return(startup_command);
             };
        
             it should_add_the_instance_of_the_initial_command_created_by_the_factory_to_its_set_of_commands_to_run = () =>
             {
                 commands.should_contain(startup_command);
             };


             static ApplicationStartupCommand startup_command;
         }

         [Concern(typeof(ApplicationStartupPipelineBuilder))]
         public class when_adding_a_pipeline_stage : concern
         {
             context c = () =>
             {
                 startup_command = an<ApplicationStartupCommand>();
                 command_factory.Stub(x => x.create(null, null)).IgnoreArguments().Return(startup_command);
             };


             because b = () =>
             {
                 result = sut.followed_by<ApplicationStartupCommand>();
             };
        
             it should_add_the_command_that_was_created_by_the_application_command_factory_to_its_list_of_commands_to_run = () =>
             {
                 commands.should_contain(startup_command);
             };

             it should_return_itself = () =>
             {
                 result.should_be_equal_to(sut);
             };

             static ApplicationStartupCommand startup_command;
             static ApplicationStartupPipelineBuilder result;
         }

         [Concern(typeof(ApplicationStartupPipelineBuilder))]
         public class when_finishing_pipeline : concern
         {
             it should_add_the_command_to_the_pipeline_is_finished_by = () =>
             {
                 commands.should_contain(last_command);
             };

             it should_run_all_commands = () =>
             {
                 commands.each(command => command.received(x=>x.run()));
             };

             because b = () =>
             {
                 sut.finish_by<ApplicationStartupCommand>();
             };

             context c = () =>
             {
                 first_command = an<ApplicationStartupCommand>();
                 last_command = an<ApplicationStartupCommand>();
                 commands.Add(first_command);
                 command_factory.Stub(x => x.create(null, null)).IgnoreArguments().Return(last_command);
                 
             };

             static ApplicationStartupCommand first_command;
             static ApplicationStartupCommand last_command;
         }
         
     }
 }
