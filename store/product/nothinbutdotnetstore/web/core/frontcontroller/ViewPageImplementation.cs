using System.Web.UI;

namespace nothinbutdotnetstore.web.core.frontcontroller
{
    public class ViewPageImplementation<Model> : Page,ViewPage<Model>
    {
        public Model model { get; set; }
    }
}