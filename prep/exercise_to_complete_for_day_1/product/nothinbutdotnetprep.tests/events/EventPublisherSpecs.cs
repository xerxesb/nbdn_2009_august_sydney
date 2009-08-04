 using developwithpassion.bdd.contexts;
 using developwithpassion.bdd.mbunit.standard.observations;
 using developwithpassion.bdddoc.core;
 using nothinbutdotnetprep.events;
 using developwithpassion.bdd.mbunit;

namespace nothinbutdotnetprep.tests.events
 {   
     public class EventPublisherSpecs
     {
         public abstract class concern : observations_for_a_sut_without_a_contract<EventPublisher>
         {
        
         }

         [Concern(typeof(EventPublisher))]
         public class when_a_subject_that_the_event_publisher_is_monitoring_publishes_an_event : concern
         {
             context c = () =>
             {
                person = new Person(); 
                alarm_clock = new AlarmClock(2000);
             };

             after_the_sut_has_been_created ac = () =>
             {
                 sut.register_listener(Events.the_alarm_rang,person.wake_up);
                 sut.register_publisher(Events.the_alarm_rang,alarm_clock,"ring");
             };

             because b = () =>
             {
                 alarm_clock.ring_alarm();
             };

        
             it should_propagate_the_notifications_to_all_of_the_handlers = () =>
             {
                person.woke_up.should_be_true();
             };

             static Person person;
             static AlarmClock alarm_clock;
         }
     }
 }
