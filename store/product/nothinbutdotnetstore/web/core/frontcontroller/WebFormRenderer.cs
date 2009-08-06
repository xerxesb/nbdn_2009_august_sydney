using System.Web;
using System.Web.Compilation;

namespace nothinbutdotnetstore.web.core.frontcontroller
{
    public class WebFormRenderer : ItemRenderer
    {
        static public WebFormViewFactory web_form_view_factory = BuildManager.CreateInstanceFromVirtualPath;
        static public TransferAction transfer_action = (handler, preserve) => HttpContext.Current.Server.Transfer(handler, preserve);

        WebFormViewRegistry view_registry;

        public WebFormRenderer(WebFormViewRegistry view_registry)
        {
            this.view_registry = view_registry;
        }

        public void render<ViewModel>(ViewModel view_model)
        {
            var view_information = view_registry.get_view_information_for<ViewModel>();
            var view = (ViewPage<ViewModel>) web_form_view_factory(view_information.path, view_information.type);
            view.model = view_model;
            transfer_action(view, true);
        }
    }
}