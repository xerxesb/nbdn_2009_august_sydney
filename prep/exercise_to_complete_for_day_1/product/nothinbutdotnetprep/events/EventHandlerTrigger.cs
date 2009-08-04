using System;
using System.ComponentModel;

namespace nothinbutdotnetprep.events
{
    public class EventHandlerTrigger
    {
        EventHandlerList handlers;
        string global_name;

        public EventHandlerTrigger(EventHandlerList handlers, string global_name)
        {
            this.handlers = handlers;
            this.global_name = global_name;
        }

        public void trigger(object sender, EventArgs e)
        {
            handlers[global_name].DynamicInvoke(sender, e);
        }
    }
}