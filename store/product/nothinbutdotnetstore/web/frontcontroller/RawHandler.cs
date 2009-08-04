using System;
using System.Web;

namespace nothinbutdotnetstore.web.frontcontroller
{
    public class RawHandler : IHttpHandler
    {
        FrontController front_controller;

        static public IncomingRequestFactory request_factory = delegate
        {
            throw new Exception("You need to implement this");
        };

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