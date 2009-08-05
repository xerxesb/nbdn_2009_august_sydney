using System.Collections.Generic;
using developwithpassion.bdd;
using developwithpassion.bdd.contexts;
using developwithpassion.bdd.mbunit.standard.observations;
using developwithpassion.bdddoc.core;
using nothinbutdotnetstore.dto;
using nothinbutdotnetstore.infrastructure;
using nothinbutdotnetstore.tasks;
using nothinbutdotnetstore.web.application.catalogbrowsing;
using nothinbutdotnetstore.web.frontcontroller;
using Rhino.Mocks;

namespace nothinbutdotnetstore.tests.web
{
    public class ViewSubDepartmentsInDepartmentSpecs
    {
        public abstract class concern : observations_for_a_sut_with_a_contract<RawRequestCommand,
                                            ViewSubDepartmentsInDepartment> {}

        [Concern(typeof (ViewSubDepartmentsInDepartment))]
        public class when_displaying_the_list_of_departments_in_a_subdepartment : concern
        {
            context c = () =>
            {
                request = an<IncomingRequest>();
                department_id = an<Id<long>>();
                display_engine = the_dependency<DisplayEngine>();
                catalog_tasks = the_dependency<CatalogTasks>();

                sub_departments = new List<DepartmentItem>();

                request.Stub(x => x.map<Id<long>>()).Return(department_id);
                catalog_tasks.Stub(x => x.get_all_subdepartments_in(department_id)).Return(sub_departments);
            };

            because b = () =>
            {
                sut.process(request);
            };


            it should_display_all_of_the_subdepartments_in_the_department = () =>
            {
                display_engine.received(x => x.display(sub_departments));
            };

            static DisplayEngine display_engine;
            static IEnumerable<DepartmentItem> sub_departments;
            static IncomingRequest request;
            static CatalogTasks catalog_tasks;
            static Id<long> department_id;
        }
    }
}