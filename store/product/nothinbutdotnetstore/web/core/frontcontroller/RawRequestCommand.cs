namespace nothinbutdotnetstore.web.core.frontcontroller
{
    public interface RawRequestCommand
    {
        void process(IncomingRequest request);
    }
}