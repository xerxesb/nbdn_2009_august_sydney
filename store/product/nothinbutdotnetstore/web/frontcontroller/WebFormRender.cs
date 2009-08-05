using System.Web;
using System.Web.Compilation;

namespace nothinbutdotnetstore.web.frontcontroller
{
    public class WebFormRender : ItemRender
    {
        static public WebFormViewFactory web_form_view_factory = BuildManager.CreateInstanceFromVirtualPath;
        static public TransferAction transfer_action = (handler, preserve) => HttpContext.Current.Server.Transfer(handler, preserve);


        WebFormViewRegistry view_registry;

        public WebFormRender(WebFormViewRegistry view_registry)
        {
            this.view_registry = view_registry;
        }

        public void render<Item>(Item item)
        {
            var view_information = view_registry.get_view_information_for<Item>();
            var view = (ViewPage<Item>) web_form_view_factory(view_information.path, view_information.type);
            view.model = item;
            transfer_action(view, true);
        }
    }
}