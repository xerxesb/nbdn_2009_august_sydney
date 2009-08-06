using System;

namespace nothinbutdotnetstore.web.core.frontcontroller
{
    public class WebFormViewInformationNotMappedException : Exception
    {
        public WebFormViewInformationNotMappedException(Type type_not_mapped) 
        {
            this.type_not_mapped = type_not_mapped;
        }

        public Type type_not_mapped { get; private set; }
    }
}