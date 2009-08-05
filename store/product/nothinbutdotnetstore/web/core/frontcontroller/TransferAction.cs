using System.Web;

namespace nothinbutdotnetstore.web.core.frontcontroller
{
    public delegate void TransferAction(IHttpHandler handler,bool preserve_form);
}