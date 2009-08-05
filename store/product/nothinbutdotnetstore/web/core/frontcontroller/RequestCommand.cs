namespace nothinbutdotnetstore.web.core.frontcontroller
{
    public interface RequestCommand : RawRequestCommand
    {
        bool can_handle(IncomingRequest request);
    }
}