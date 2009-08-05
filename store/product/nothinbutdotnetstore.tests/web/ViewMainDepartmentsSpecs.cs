using System.Collections.Generic;
using developwithpassion.bdd;
using developwithpassion.bdd.contexts;
using developwithpassion.bdd.mbunit.standard.observations;
using developwithpassion.bdddoc.core;
using nothinbutdotnetstore.dto;
using nothinbutdotnetstore.tasks;
using nothinbutdotnetstore.web.application.catalogbrowsing;
using nothinbutdotnetstore.web.core.frontcontroller;
using Rhino.Mocks;

namespace nothinbutdotnetstore.tests.web
{
    public class ViewMainDepartmentsSpecs
    {
        public abstract class concern : observations_for_a_sut_with_a_contract<RawRequestCommand,
                                            ViewMainDepartments> {}

        [Concern(typeof (ViewMainDepartments))]
        public class when_displaying_a_list_of_the_main_departments : concern
        {
            context c = () =>
            {
                main_departments = new List<DepartmentItem>();
                catalog_tasks = the_dependency<CatalogTasks>();
                display_engine = the_dependency<DisplayEngine>();
                request = an<IncomingRequest>();
                catalog_tasks.Stub(x => x.get_all_main_departments()).Return(main_departments);
            };

            because b = () =>
            {
                sut.process(request);
            };


            it should_display_a_list_of_all_of_the_main_departments_in_the_store = () =>
            {
                display_engine.received(x => x.display(main_departments));
            };

            static DisplayEngine display_engine;
            static IEnumerable<DepartmentItem> main_departments;
            static IncomingRequest request;
            static CatalogTasks catalog_tasks;
        }
    }
}