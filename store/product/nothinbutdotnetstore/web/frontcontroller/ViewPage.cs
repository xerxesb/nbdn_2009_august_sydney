using System.Web;

namespace nothinbutdotnetstore.web.frontcontroller
{
    public interface ViewPage<Model> : IHttpHandler
    {
        Model model { get; set; } 
    }
}