 using System;
 using System.Collections.Generic;
 using developwithpassion.bdd;
 using developwithpassion.bdd.contexts;
 using developwithpassion.bdd.mbunit.standard.observations;
 using developwithpassion.bdddoc.core;
 using nothinbutdotnetstore.tasks;
 using nothinbutdotnetstore.tasks.startup;
 using Rhino.Mocks;
 using developwithpassion.bdd.mbunit;

namespace nothinbutdotnetstore.tests.tasks
 {   
     public class ApplicationStartupPipelineBuilderSpecs
     {
         public abstract class concern : observations_for_a_sut_without_a_contract<ApplicationStartupPipelineBuilder>
         {
             context c = () =>
             {
                 commands = new List<ApplicationStartupCommand>();
                 command_constructor = the_dependency<ApplicationStartupCommandConstructor>();
             };

             public override ApplicationStartupPipelineBuilder create_sut()
             {
                 return new ApplicationStartupPipelineBuilder(command_constructor, commands);
             }

             protected static ApplicationStartupCommandConstructor command_constructor;
             protected static List<ApplicationStartupCommand> commands;

         }

         [Concern(typeof(ApplicationStartupPipelineBuilder))]
         public class when_adding_a_pipeline_stage : concern
         {
             context c = () =>
             {
                 startup_command = an<ApplicationStartupCommand>();
                 command_constructor.Stub(x => x.create(null, null)).IgnoreArguments().Return(startup_command);
             };


             because b = () =>
             {
                 result = sut.followed_by<ApplicationStartupCommand>();
             };
        
             it should_construct_a_instance_of_the_command_with_its_container_registry = () =>
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
             it should_add_command_the_pipeline_is_finished_by = () =>
             {
                 commands.should_contain(last_command);
             };

             it should_run_all_commands = () =>
             {
                 commands.ForEach(command => command.received(x=>x.run()));
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
                 command_constructor.Stub(x => x.create(null, null)).IgnoreArguments().Return(last_command);
                 
             };

             static ApplicationStartupCommand first_command;
             static ApplicationStartupCommand last_command;
         }
         
     }
 }
