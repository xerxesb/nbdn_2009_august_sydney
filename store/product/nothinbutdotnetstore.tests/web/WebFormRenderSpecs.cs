using System;
using System.Web;
using developwithpassion.bdd.contexts;
using developwithpassion.bdd.mbunit;
using developwithpassion.bdd.mbunit.standard.observations;
using developwithpassion.bdddoc.core;
using nothinbutdotnetstore.web.core.frontcontroller;
using Rhino.Mocks;

namespace nothinbutdotnetstore.tests.web
{
    public class WebFormRenderSpecs
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
                page_info = new WebFormViewInformation {type = typeof (ViewPage<int>), path = "blah.aspx"};

                transfer_action = (handler, preserve) =>
                {
                    handler_that_was_run = handler;
                };

                web_form_view_factory = (path, type) =>
                {
                    info_used_to_create_type = new WebFormViewInformation(path, type);
                    return page;
                };

                web_form_view_registry = the_dependency<WebFormViewRegistry>();
                web_form_view_registry.Stub(x => x.get_view_information_for<int>()).Return(page_info);

                change(() => WebFormRender.web_form_view_factory).to(web_form_view_factory);
                change(() => WebFormRender.transfer_action).to(transfer_action);
            };

            because b = () =>
            {
                sut.render(item_to_render);
            };


            it should_display_the_page_populated_with_the_information_it_needs_to_display = () =>
            {
                page.model.should_be_equal_to(item_to_render);
                info_used_to_create_type.type.should_be_equal_to(page_info.type);
                info_used_to_create_type.path.should_be_equal_to(page_info.path);
                handler_that_was_run.should_be_equal_to(page);
            };

            static WebFormViewFactory web_form_view_factory;
            static TransferAction transfer_action;
            static Page<int> page;
            static WebFormViewRegistry web_form_view_registry;
            static WebFormViewInformation page_info;
            static WebFormViewInformation info_used_to_create_type;
            static int item_to_render = 42;
            static IHttpHandler handler_that_was_run;
        }

        public class when_created_without_swapping_its_defaults : concern {

            it should_throw_an_exception = () =>
            {
                


            };
        }
    }
}