namespace nothinbutdotnetstore.web.frontcontroller
{
    public interface RawRequestCommand
    {
        void process(IncomingRequest request);
    }
}