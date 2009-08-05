using System.Collections.Generic;
using developwithpassion.bdd;
using developwithpassion.bdd.contexts;
using developwithpassion.bdd.mbunit.standard.observations;
using developwithpassion.bdddoc.core;
using nothinbutdotnetstore.web.commands;
using nothinbutdotnetstore.web.frontcontroller;
using nothinbutdotnetstore.web.models;
using nothinbutdotnetstore.web.presenters;
using nothinbutdotnetstore.web.services;
using nothinbutdotnetstore.web.services.viewmaindepartments;
using nothinbutdotnetstore.web.viewmodels;
using nothinbutdotnetstore.web.views;
using Rhino.Mocks;

namespace nothinbutdotnetstore.tests.web
{
    public class ViewMainDepartmentsCommandSpec
    {
        public abstract class concern : observations_for_a_sut_with_a_contract<RawRequestCommand,
                                            ViewMainDepartmentsCommand> {}

        [Concern(typeof (ViewMainDepartmentsCommand))]
        public class when_processing_a_request : concern
        {
            context c = () =>
            {
                request = an<IncomingRequest>();
                departments = an<IEnumerable<Department>>();

                main_departments_lister = the_dependency<DepartmentRegistry>();
                display_engine = the_dependency<DisplayEngine>();

                main_departments_lister.Stub(x => x.get_main_departments()).Return(departments);
            };

            because b = () =>
            {
                sut.process(request);
            };

            it should_tell_the_display_engine_to_display_the_list_of_main_departments = () =>
            {
                display_engine.received(x => x.display(departments));
            };


            static DepartmentRegistry main_departments_lister;
            static IncomingRequest request;
            static IEnumerable<Department> departments;
            static DisplayEngine display_engine;
        }
    }
}