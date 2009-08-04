 using System;
 using developwithpassion.bdd.contexts;
 using developwithpassion.bdd.mbunit.standard.observations;
 using developwithpassion.bdddoc.core;
 using nothinbutdotnetprep.events;
 using developwithpassion.bdd.mbunit;

namespace nothinbutdotnetprep.tests.events
 {   
     public class AlarmClockSpecs
     {
         public abstract class concern : observations_for_a_sut_without_a_contract<AlarmClock>
         {
        
         }

         [Concern(typeof(AlarmClock))]
         public class when_an_alarm_rings : concern
         {
             /// <summary>
             /// Create the event args type
             /// Create the delegate signature for the event handler
             /// Create the type that exposes the event
             /// Raise the event at the appropriate time
             /// </summary>
             context c = () =>
             {
                provide_a_basic_sut_constructor_argument(3000);  
             };

             after_the_sut_has_been_created ac = () =>
             {
                 sut.ring += (o, e) => result = e;
             };

             because b = () =>
             {
                 sut.start(); 
             };

        
             it should_provide_access_to_all_of_the_required_information_about_the_status_of_the_alarm_clock = () =>
             {
                result.time_the_alarm_was_started.should_be_less_than(DateTime.Now);
                result.time_the_alarm_rang.should_be_greater_than(result.time_the_alarm_was_started);
             };

             static AlarmRingEventArgs result;
         }
     }
 }
