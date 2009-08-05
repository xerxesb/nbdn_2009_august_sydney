using System.Collections.Generic;
using developwithpassion.bdd;
using developwithpassion.bdd.contexts;
using developwithpassion.bdd.mbunit.standard.observations;
using developwithpassion.bdddoc.core;
using nothinbutdotnetstore.dto;
using nothinbutdotnetstore.infrastructure;
using nothinbutdotnetstore.tasks;
using nothinbutdotnetstore.web.application.catalogbrowsing;
using nothinbutdotnetstore.web.core.frontcontroller;
using Rhino.Mocks;

namespace nothinbutdotnetstore.tests.web
{
    public class ViewProductsInDepartmentSpecs
    {
        public abstract class concern : observations_for_a_sut_with_a_contract<RawRequestCommand,
                                            ViewProductsInDepartments> {}

        [Concern(typeof (ViewProductsInDepartments))]
        public class when_displaying_the_products_in_a_department : concern
        {
            context c = () =>
            {
                request = an<IncomingRequest>();
                display_engine = the_dependency<DisplayEngine>();
                catalog_tasks = the_dependency<CatalogTasks>();
                department_id = an<Id<long>>();

                products_in_department = new List<ProductItem>();

                request.Stub(x => x.map<Id<long>>()).Return(department_id);
                catalog_tasks.Stub(x => x.get_all_products_in(department_id)).Return(products_in_department);
            };

            because b = () =>
            {
                sut.process(request);
            };


            it should_display_the_products_that_belong_to_the_requested_department = () =>
            {
                display_engine.received(x => x.display(products_in_department));
            };

            static DisplayEngine display_engine;
            static IEnumerable<ProductItem> products_in_department;
            static IncomingRequest request;
            static CatalogTasks catalog_tasks;
            static Id<long> department_id;
        }
    }
}