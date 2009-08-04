using System;

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

        void OnRing()
        {
            ring(this,EventArgs.Empty);
        }


        [PublishEvent(Events.the_alarm_rang)]
        public event EventHandler ring = delegate {};

        public void ring_alarm()
        {
            OnRing();
        }
    }
}