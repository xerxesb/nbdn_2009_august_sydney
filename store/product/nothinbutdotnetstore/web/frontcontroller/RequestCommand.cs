namespace nothinbutdotnetstore.web.frontcontroller
{
    public interface RequestCommand : RawRequestCommand
    {
        bool can_handle(IncomingRequest request);
    }
}