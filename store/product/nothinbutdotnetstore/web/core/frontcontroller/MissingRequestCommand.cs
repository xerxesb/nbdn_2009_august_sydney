using System;

namespace nothinbutdotnetstore.web.core.frontcontroller
{
    public class MissingRequestCommand : RequestCommand
    {
        public void process(IncomingRequest request)
        {
            throw new NotImplementedException();
        }

        public bool can_handle(IncomingRequest request)
        {
            throw new NotImplementedException();
        }
    }
}