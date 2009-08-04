using System;

namespace nothinbutdotnetprep.events
{
    public class Person
    {
        public bool woke_up { get; set; }

        public void wake_up(object sender, EventArgs e)
        {
            woke_up = true;
        }
    }
}