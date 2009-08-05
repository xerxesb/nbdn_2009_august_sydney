using System.Web;

namespace nothinbutdotnetstore.web.core.frontcontroller
{
    public delegate IncomingRequest IncomingRequestFactory(HttpContext context);
}