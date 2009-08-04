using System;

namespace nothinbutdotnetprep.events
{
    [AttributeUsage(AttributeTargets.Method)]
    public class SubscribeToEventAttribute: Attribute
    {
        public string name { get; set; }

        public SubscribeToEventAttribute(string name)
        {
            this.name = name;
        }
    }
}