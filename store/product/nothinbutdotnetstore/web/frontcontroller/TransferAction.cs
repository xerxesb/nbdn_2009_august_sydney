using System.Web;

namespace nothinbutdotnetstore.web.frontcontroller
{
    public delegate void TransferAction(IHttpHandler handler,bool preserve_form);
}