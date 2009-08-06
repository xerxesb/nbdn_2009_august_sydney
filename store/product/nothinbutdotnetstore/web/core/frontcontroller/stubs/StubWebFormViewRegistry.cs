using System.Collections.Generic;
using nothinbutdotnetstore.dto;

namespace nothinbutdotnetstore.web.core.frontcontroller.stubs
{
    public class StubWebFormViewRegistry : WebFormViewRegistry
    {
        public WebFormViewInformation get_view_information_for<ViewModel>()
        {
            return new WebFormViewInformation("~/views/DepartmentBrowser.aspx", typeof (ViewPage<IEnumerable<DepartmentItem>>));
        }
    }
}