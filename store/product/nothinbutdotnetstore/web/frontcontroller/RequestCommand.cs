namespace nothinbutdotnetstore.web.frontcontroller
{
    public interface RequestCommand
    {
        void process(IncomingRequest request);
    }
}