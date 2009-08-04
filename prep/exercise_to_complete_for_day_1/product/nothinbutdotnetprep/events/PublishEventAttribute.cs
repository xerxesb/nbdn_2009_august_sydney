using System;

namespace nothinbutdotnetprep.events
{
    [AttributeUsage(AttributeTargets.Event)]
    public class PublishEventAttribute : Attribute
    {
        public string name { get; set; }

        public PublishEventAttribute(string name)
        {
            this.name = name;
        }
    }
}