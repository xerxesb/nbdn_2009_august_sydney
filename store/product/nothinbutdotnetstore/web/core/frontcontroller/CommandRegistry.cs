namespace nothinbutdotnetstore.web.core.frontcontroller
{
    public interface CommandRegistry
    {
        RequestCommand get_command_that_can_handle(IncomingRequest request);
    }
}