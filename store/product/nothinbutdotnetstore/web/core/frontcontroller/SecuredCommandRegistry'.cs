using System;

namespace nothinbutdotnetstore.web.core.frontcontroller
{
    public class SecuredCommandRegistry : CommandRegistry
    {
        CommandRegistry to_secure;
        public SecuredCommandRegistry(CommandRegistry to_secure)
        {
            this.to_secure = to_secure;
        }

        public RequestCommand get_command_that_can_handle(IncomingRequest request)
        {
            perform_security_check();
            return to_secure.get_command_that_can_handle(request);
        }

        void perform_security_check()
        {
        }
    }
}