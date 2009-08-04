using System;

namespace nothinbutdotnetprep.events
{
    public class AlarmRingEventArgs
    {
        public DateTime time_the_alarm_was_started { get; set; }

        public DateTime time_the_alarm_rang { get; set; }
    }
}