using System.Web;

namespace nothinbutdotnetstore.web.core.frontcontroller
{
    public class RawHandler : IHttpHandler
    {
        FrontController front_controller;

        static public IncomingRequestFactory request_factory = x => null;

        public RawHandler():this(new FrontControllerImplementation()) {}

        public RawHandler(FrontController front_controller)
        {
            this.front_controller = front_controller;
        }

        public bool IsReusable
        {
            get { return true; }
        }

        public void ProcessRequest(HttpContext context)
        {
            front_controller.process(request_factory(context));
        }
    }
}