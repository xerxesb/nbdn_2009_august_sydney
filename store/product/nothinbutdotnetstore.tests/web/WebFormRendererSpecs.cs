using System;
using System.Web;
using developwithpassion.bdd.contexts;
using developwithpassion.bdd.mbunit;
using developwithpassion.bdd.mbunit.standard.observations;
using developwithpassion.bdddoc.core;
using nothinbutdotnetstore.web.frontcontroller;
using Rhino.Mocks;

namespace nothinbutdotnetstore.tests.web
{
    public class WebFormRendererSpecs
    {
        public abstract class concern : observations_for_a_sut_with_a_contract<ItemRender,
                                            WebFormRender> {}

        public class Page<T> : ViewPage<T>
        {
            public T model { get; set; }

            public void ProcessRequest(HttpContext context)
            {
                throw new NotImplementedException();
            }

            public bool IsReusable
            {
                get { throw new NotImplementedException(); }
            }
        }

        [Concern(typeof (WebFormRender))]
        public class when_rendering_an_item : concern
        {
            context c = () =>
            {
                page = new Page<int>();
                page_info = new WebFormViewInformation { type = typeof(ViewPage<int>), path = "blah.aspx" };

                view_factory = (name, type) =>
                {
                    page_name_to_display = name;
                    page_type_to_create = type;
                    return page;
                };

                web_form_view_registry = the_dependency<WebFormViewRegistry>();
                web_form_view_registry.Stub(x => x.get_view_information_for<int>()).Return(page_info);
                change(() => WebFormRender.view_factory).to(view_factory);
            };

            because b = () =>
            {
                sut.render(23);
            };


            it should_display_the_page_populated_with_the_information_it_needs_to_display = () =>
            {
                page.model.should_be_equal_to(23);
            };

            static ViewFactory view_factory;
            static Page<int> page;
            static WebFormViewRegistry web_form_view_registry;
            static WebFormViewInformation page_info;
            static string page_name_to_display;
            static Type page_type_to_create;
        }
    }
}