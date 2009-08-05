using System.Web;
using developwithpassion.bdd;
using developwithpassion.bdd.contexts;
using developwithpassion.bdd.mbunit.standard.observations;
using developwithpassion.bdddoc.core;
using nothinbutdotnetstore.web.core.frontcontroller;

namespace nothinbutdotnetstore.tests.web
{
    public class RawHandlerSpecs
    {
        public abstract class concern : observations_for_a_sut_with_a_contract<IHttpHandler,
                                            RawHandler> {}

        [Concern(typeof (RawHandler))]
        public class when_processing_an_http_context : concern
        {
            context c = () =>
            {
                item = null;
                front_controller = the_dependency<FrontController>();
                request = an<IncomingRequest>();

                IncomingRequestFactory factory = http_context => request;
                change(() => RawHandler.request_factory).to(factory);
            };

            because b = () =>
            {
                sut.ProcessRequest(item);
            };


            it should_delegate_the_processing_to_the_front_controller = () =>
            {
                front_controller.received(x => x.process(request));
            };

            static FrontController front_controller;
            static IncomingRequest request;
            static HttpContext item;
            static IncomingRequestFactory request_factory;
        }
    }
}