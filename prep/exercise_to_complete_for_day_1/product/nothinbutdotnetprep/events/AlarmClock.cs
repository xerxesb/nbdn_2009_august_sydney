using System;
using System.Threading;

namespace nothinbutdotnetprep.events
{
    public class AlarmClock
    {
        readonly int _ringAfterMilliseconds;

        public AlarmClock(int ring_after_milliseconds)
        {
            _ringAfterMilliseconds = ring_after_milliseconds;
        }

        public void start()
        {
            OnRing();
        }

        private void OnRing()
        {
            var temp_alarm_event = ring;
            if (temp_alarm_event != null) 
            {
                temp_alarm_event(this, new AlarmRingEventArgs 
                {
                    time_the_alarm_was_started = DateTime.Now, 
                    time_the_alarm_rang = DateTime.Now.AddMilliseconds(_ringAfterMilliseconds)
                });
            }
        }

        public delegate AlarmRingEventArgs AlarmRingDelegate(object sender, AlarmRingEventArgs e);
        public event AlarmRingDelegate ring;

    }
}