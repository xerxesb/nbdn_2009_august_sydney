using System;
using System.ComponentModel;
using nothinbutdotnetprep.infrastructure.extensions;

namespace nothinbutdotnetprep.events
{
    public class EventPublisher
    {
        EventHandlerList handlers = new EventHandlerList();

        public void register_listener(string global_event_name, EventHandler listener)
        {
            handlers.AddHandler(global_event_name, listener);
        }

        public void register_publisher(string global_event_name, object subject, string real_event_name_on_subject)
        {
            var type = subject.GetType();
            var event_info = type.GetEvent(real_event_name_on_subject);
            event_info.AddEventHandler(subject, create_handler_to_publish(global_event_name));
        }

        EventHandler create_handler_to_publish(string global_event_name)
        {
            return (o, e) =>
            {
                var handler = handlers[global_event_name];
                handler.downcast_to<EventHandler>()(o, e);
            };
        }
    }
}