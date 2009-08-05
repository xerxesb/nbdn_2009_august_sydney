using System;

namespace nothinbutdotnetstore.web.core.frontcontroller
{
    public class WebFormViewInformation
    {
        public Type type { get; set; }
        public string path { get; set; }

        public WebFormViewInformation(string path, Type type)
        {
            this.type = type;
            this.path = path;
        }

        public WebFormViewInformation() {}
    }
}