using System.Web;

namespace nothinbutdotnetstore.web.core.frontcontroller
{
    public interface ViewPage<Model> : IHttpHandler
    {
        Model model { get; set; } 
    }
}