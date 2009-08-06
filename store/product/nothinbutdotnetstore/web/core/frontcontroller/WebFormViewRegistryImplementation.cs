using System;
using System.Collections.Generic;

namespace nothinbutdotnetstore.web.core.frontcontroller
{
    public class WebFormViewRegistryImplementation : WebFormViewRegistry
    {
        IDictionary<Type, WebFormViewInformation> mappings;
        public WebFormViewRegistryImplementation(IDictionary<Type, WebFormViewInformation> mappings)
        {
            this.mappings = mappings;
        }

        public WebFormViewInformation get_view_information_for<ViewModel>()
        {
            if (!mappings.ContainsKey(typeof(ViewModel))) throw new WebFormViewInformationNotMappedException(typeof(ViewModel));
            return mappings[typeof (ViewModel)];
        }
    }
}